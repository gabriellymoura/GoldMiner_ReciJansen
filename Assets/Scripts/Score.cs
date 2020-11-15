using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 400;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public int timePerLevel = 30; //tempo maximo
    public GameObject ganhou;
    public GameObject perdeu;

    private float clockSpeed = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText.text = ("Score: " + score + "/" + targetScore);
        InvokeRepeating("Clock", 0, clockSpeed);
    }
    
    void Clock(){
        timePerLevel--;
        timeText.text = ("Time: " + timePerLevel);
        if(timePerLevel == 0){
             checkGameOver();
        }
    }

    public void addPoints(int points){
        score += points;
        scoreText.text = ("Score: " + score + "/" + targetScore);
    }

    void checkGameOver(){
        if(score >= targetScore){
            Time.timeScale = 0;
            ganhou.SetActive(true);
            
        }
        else{
            Time.timeScale = 0;
            perdeu.SetActive(true);
        }
    }


    // Update is called once per frame

}
