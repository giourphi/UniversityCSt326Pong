using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerScored;    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!playerScored)
            {
                Debug.Log("Player 1 scored");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().player1Scored();
            }
            else
            {
                Debug.Log("Player 2 scored");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().player2Scored();
            }
        }
    }
}
