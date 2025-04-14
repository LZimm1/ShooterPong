using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    private static int highScoreNum = 0;
    private int intScore = (int)(PlayerMovement.Score * 100);
    public Text scoreText;
    
    public Text highScore;
    
    public Text AccuracyText;
    private float accuracy;
    

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "GameOver"){
            scoreText.text = intScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(Shoot.bulletsShot != 0){
            accuracy =  100 * ((float)BulletMovement.bulletsHit / (float)Shoot.bulletsShot);
        }
        intScore = (int)(PlayerMovement.Score * 100);
        if(SceneManager.GetActiveScene().name == "Game"){
            scoreText.text = intScore.ToString();
        }
        if(AccuracyText){
            AccuracyText.text = accuracy.ToString() + "%";
        }
        if(intScore > highScoreNum){
            highScoreNum = intScore;
        }
        if(highScore){
            highScore.text = highScoreNum.ToString();
        }
    }
}
