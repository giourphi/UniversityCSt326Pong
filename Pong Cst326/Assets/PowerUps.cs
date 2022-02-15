using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PowerUps : MonoBehaviour
{

    public bool isPoweredUp;
    public Rigidbody2D r; 
    public Vector3 startpos;

    public float speed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
         
    //    Vector2 direction = (Random.value < 0.5f) ? Vector2.right : Vector2.left;
      //  r.velocity = direction * speed;
    }

    // Update is called once per frame
    public void Reset()
    {
        transform.position = startpos;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            if (!isPoweredUp)
            {
                Debug.Log("powerup 1 was hit");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().powerup1hit();
               // Destroy(col.GetComponent<GameManagerScript>().powerup1);
            }
            else
            {
                Debug.Log("powerup 2 was hit");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().powerup2hit();
                //Destroy(col.GetComponent<GameManagerScript>().powerup2);
            }
            
            
        }
    }
}
