using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
  [Header("Player 1")]  
  public GameObject player1;
  public GameObject player1Goal;

  [Header("Ball")]
  public GameObject ball;
    
  [Header("Player 2")]
  public GameObject player2;
  public GameObject player2Goal;

  [Header("Score UI")] 
  public GameObject Player1Text;
  public GameObject Player2Text;

  private int player1Score;
  private int player2Score; 
  
  
  
    public  void player1Scored()
    {
        player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString(); 
        //Debug.Log(player1Score);
        ResetPosition();
    }

    public void player2Scored()
    {
        player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
       // Debug.Log(player2Score);
     
       ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<PaddleControl>().Reset();
        player2.GetComponent<PaddleControl>().Reset();
    }
}
