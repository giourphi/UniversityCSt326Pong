using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Ball : MonoBehaviour
{
    public float speed;
    public float acceleartonhit = .05f;
    public Rigidbody2D r;
    private int hitcounter;
    public AudioSource tickSource;
    public AudioSource tickSource2;
    public bool isplayer1 =false; 

    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        tickSource2 = GetComponent<AudioSource>();
        startpos = transform.position;
        Launcher(); 
        
    }

    // Update is called once per frame
   

    public void Reset()
    {
        r.velocity = Vector2.zero;
        hitcounter = 0;
       

      /*  if (GameObject.Find("Goal1").GetComponent<GameManagerScript>().player1Goal)
        {
            transform.position = Vector3.right;
        }

        if (GameObject.Find("Goal2").GetComponent<GameManagerScript>().player2Goal)
        {
            transform.position = Vector3.left;
        }
        else
        {
            transform.position = startpos;
        }
*/
        transform.position = startpos;
        Launcher();
    }

    private void Launcher()
    {   
      
        
            Vector2 direction = (Random.value < 0.5f) ? Vector2.right : Vector2.left;
            r.velocity = direction * speed;
        
    }

    float hitfactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "PaddleLeft")
        {
            if (!isplayer1)
            {
                tickSource.Play();
            }

            HandleRacketCollision(col, 1);
        }else if (col.gameObject.name == "PaddleRight")
        {
            isplayer1 = true; 
            if (isplayer1)
            {
                tickSource2.Play();
            }

            HandleRacketCollision(col, -1);
        }
       
    }



     private void HandleRacketCollision(Collision2D col, int bounceDirectionX)
     {
         hitcounter++;

         float y = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.y);

         Vector2 direction = new Vector2(bounceDirectionX, y).normalized;

         r.velocity = direction * (speed + (hitcounter * acceleartonhit));

     }
}
