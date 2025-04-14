using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool AdvanceToGame = false;
    public static bool AdvanceToTutorial = false;
    public static bool BackToMenu = false;

    public static GameManager instance;
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadGame();
        LoadTut();
        GameOver();
        LoadBackToMenu();
        if(SceneManager.GetActiveScene().name == "Game"){
            Cursor.visible = false;
        }
        else{
            Cursor.visible = true;
        }
    }
    void LoadGame(){
        if(AdvanceToGame){
            SceneManager.LoadScene("Game");
            AdvanceToGame = false;
            BulletMovement.bulletsHit = 0;
            Shoot.bulletsShot = 0;
            PlayerMovement.Score = 0;
        }
    }
    void LoadTut(){
        if(AdvanceToTutorial){
            SceneManager.LoadScene("How To Play");
            AdvanceToTutorial = false;
        }
    }
    void LoadBackToMenu(){
        if(BackToMenu){
            SceneManager.LoadScene("Menu");
            BackToMenu = false;
        }
    }
    void GameOver(){
        if(BulletMovement.gameOver){
            SceneManager.LoadScene("GameOver");
            BulletMovement.gameOver = false;
        }
    }
}
