using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
  public GameObject gameover;
  private int player1Score;
  private int player2Score; 
  TextMeshPro text;
  
  bool  maxscore = false;
  
  
  
    public  void player1Scored()
    {
        player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString(); 
        //Debug.Log(player1Score);
        if (player1Score ==11)
        {
            maxscore = true; 
            Stop();
        }
        ResetPosition();
    }

    public void player2Scored()
    {
        player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
       // Debug.Log(player2Score);
       if (player2Score == 11)
       {
           maxscore = true;
           Stop();
       }
       ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<PaddleControl>().Reset();
        player2.GetComponent<PaddleControl>().Reset();
        
    }


    private void Stop()
    {
        if (maxscore && player1Score ==11)
        {
         
            string player = "Player 1 Wins!!";
            
            gameover.GetComponent<TextMeshProUGUI>().text =player;
            Debug.Log("Player 1 wins game over");
            player1Score = 0;
            gameover.GetComponent<TextMeshProUGUI>().text = "";
            ResetPosition();
        }else if (maxscore && player2Score==11)
        {
            string player = "Player 2 Wins!!";
            gameover.GetComponent<TextMeshProUGUI>().text = player; 
            Debug.Log("Player 2 wins Game over");
            player2Score = 0;
            gameover.GetComponent<TextMeshProUGUI>().text = "";
            ResetPosition();   
        }
    }
}
