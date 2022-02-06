using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Ball : MonoBehaviour
{
    public float speed;
    public float acceleartonhit = .05f;
    public Rigidbody2D r;
    private int hitcounter;
   

    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        Launcher(); 
        
    }

    // Update is called once per frame
   

    public void Reset()
    {
        r.velocity = Vector2.zero;
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
            HandleRacketCollision(col, 1);
        }else if (col.gameObject.name == "PaddleRight")
        {
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
