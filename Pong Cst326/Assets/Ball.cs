using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Ball : MonoBehaviour
{
    public float speed;

    public Rigidbody2D r;

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
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        r.velocity = new Vector2(speed * x, speed * y);
        
    }
}
