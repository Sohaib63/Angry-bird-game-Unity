using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard             //Singleton Class
{
    private int score;
    private int kills;  
    private int attempts;
    public Text scoreText;

    private static ScoreBoard Instance ;    

    private ScoreBoard()
    {
        scoreText=GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<Text>();
    }

    public static ScoreBoard GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ScoreBoard();
        }
        return Instance;
    }

    public void AddScore(int score)
    {
        this.score += score;
        //Debug.Log("Score: " + this.score);      //Monobehaviour is not used so Debug.Log is used to print
        scoreText.text="Score: "+this.score;
    }

    public int getScore()
    {
        return this.score;
    }
    public void AddKill()
    {
        kills++;
    }

    public void AddAttempt()
    {
        attempts++;
    }


}
