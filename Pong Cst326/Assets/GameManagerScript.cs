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
  
  [Header("Powerup1")]
  public GameObject powerup1;

  [Header("Powerup2")] 
  public GameObject powerup2;
  

  [Header("Score UI")] 
  public GameObject Player1Text;
  public GameObject Player2Text;
  public GameObject gameover;
  private int player1Score;
  private int player2Score; 
  TextMeshPro text;
  
  bool  maxscore = false;
  public AudioSource gameoversound;
  private Collider2D col;



  public void powerup1hit()
  {

      Vector3 scale = transform.localScale;
      scale.x = 10f;
      player1.transform.localScale = scale;


  }

  public void powerup2hit()
      {
          Vector3 scale = transform.localScale;
          scale.x = 2f; 
          player2.transform.localScale = scale;
      
              

      }

    public  void player1Scored()
    {
        player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        Player1Text.GetComponent <TextMeshProUGUI>().color = Color.blue;
        Player2Text.GetComponent<TextMeshProUGUI>().color = Color.white;
        //Debug.Log(player1Score);
        if (player1Score >=11)
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
        Player2Text.GetComponent<TextMeshProUGUI>().color = Color.green;
       // Debug.Log(player2Score);
       Player1Text.GetComponent<TextMeshProUGUI>().color = Color.white;
       if (player2Score >= 11)
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
        ResetpowerUp();

    }

    private void ResetpowerUp()
    {
        powerup1.GetComponent<PowerUps>().Reset();
        powerup2.GetComponent<PowerUps>().Reset();
        
    }

    private void Stop()
    {
        if (maxscore && player1Score >=11)
        {
         
            string player = "Player 1 Wins!!";
            
            gameover.GetComponent<TextMeshProUGUI>().text =player;
            Debug.Log("Player 1 wins game over");
            gameoversound.Play();
            ResetPosition();
           ResetGameoverScreen();
        }else if (maxscore && player2Score>=11)
        {
            string player = "Player 2 Wins!!";
            gameover.GetComponent<TextMeshProUGUI>().text = player; 
            Debug.Log("Player 2 wins Game over");
            gameoversound.Play();
            ResetPosition();  
            ResetGameoverScreen();
        }
    }

    [ContextMenu("test")]
    private void ResetGameoverScreen()
    {
        player1Score = 0;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        player2Score = 0;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        gameover.GetComponent<TextMeshProUGUI>().text = "";
    }
        
}
