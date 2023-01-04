using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScript : MonoBehaviour
{
    //public AudioManager audioManager=AudioManager.GetInstance();
    public AudioClip monsterSound;
    public AudioClip crateSound;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "white bird")
        {
            //Destroy(gameObject);
            ScoreBoard.GetInstance().AddScore(10);
            ScoreBoard.GetInstance().AddKill();
            gameObject.SetActive(false);
            //audioManager.PlayMySound("hit monster");
            AudioSource.PlayClipAtPoint(monsterSound, transform.position);
            //LevelManager.instance.LoadNextLevel();  
        }
        else{
            ScoreBoard.GetInstance().AddScore(-5);   
        }
        if (collision.gameObject.tag == "Crate")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //audioManager.PlayMySound("Crate hit");
            AudioSource.PlayClipAtPoint(crateSound, transform.position);
        }
    }
    
}
 