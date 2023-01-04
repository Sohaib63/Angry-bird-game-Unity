using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] CanvasGameObjects;
    private int currentLevel ;
    public static LevelManager instance;


    public void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        LoadNextLevel();
    }

    public void HideAllLevels(){
        foreach(var level in levels){
            level.SetActive(false);
        }
    }

    public void LoadNextLevel(){
        if (currentLevel < levels.Length){
            HideAllLevels();
            levels[currentLevel].SetActive(true);
            currentLevel++;
        }
    }
}
