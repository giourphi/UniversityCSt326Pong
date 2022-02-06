using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public bool isPlayer;
    public Rigidbody2D r;
    public Vector3 starpos; 

    private float direction;


    void Start()
    {
        starpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer)
        {
            direction = Input.GetAxisRaw("Vertical");
        }
        else
        {
            direction = Input.GetAxisRaw("Vertical2");
        }

        r.velocity = new Vector2(r.velocity.x, direction * moveSpeed);

    }

    public void Reset()
    {
        r.velocity = Vector2.zero;
        transform.position = starpos;
    }
}
