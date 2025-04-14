using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float movementX, movementY;
    private float moveForce = 1.5f;
    private float posX,posY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    void MoveEnemy(){
        if(PlayerMovement.posX > posX){
            movementX =1;
        }
        else if(PlayerMovement.posX < posX){
            movementX = -1;
        }
        else{
            movementX = 0;
        }
        if(PlayerMovement.posY > posY){
            movementY =1;
        }
        else if(PlayerMovement.posY < posY){
            movementY = -1;
        }
        else{
            movementY = 0;
        }
        posX = transform.position.x + movementX*Time.deltaTime*moveForce;
        
        posY = transform.position.y + movementY*Time.deltaTime*moveForce;
        transform.position =new Vector3(posX,posY,0f);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ball")){
            Destroy(gameObject);
        }
    }
}
