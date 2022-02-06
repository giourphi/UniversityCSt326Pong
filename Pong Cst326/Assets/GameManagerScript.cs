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
  
  public int maxscore = 11;
  
  
  
    public  void player1Scored()
    {
        player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString(); 
        //Debug.Log(player1Score);
        if (player1Score == maxscore)
        {
            stop();
        }
        ResetPosition();
    }

    public void player2Scored()
    {
        player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
       // Debug.Log(player2Score);
       if (player2Score == maxscore)
       {
           stop();
       }
       ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<PaddleControl>().Reset();
        player2.GetComponent<PaddleControl>().Reset();
        
    }


    public void stop()
    {
        if (player1Score==maxscore-1)
        {
         
            string player = "Player 1 Wins!!";
            
            gameover.GetComponent<TextMeshProUGUI>().text =player;
            Debug.Log("Player 1 wins game over");
            player1Score = 0;
            gameover.GetComponent<TextMeshProUGUI>().text = "";
            ResetPosition();
        }else if (player2Score == maxscore-1)
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
