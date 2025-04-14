using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickPlay(){
        GameManager.AdvanceToGame = true;
    }
    public void ClickTutorial(){
        GameManager.AdvanceToTutorial = true;
    }
    public void ClickBack(){
        GameManager.BackToMenu = true;
    }
}
