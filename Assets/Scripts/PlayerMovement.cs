using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float Score = 0;
    private float moveForce = 5f;
    private float movementX, movementY;
    public static float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null){
            Score += Time.deltaTime;
        }
        MovePlayer();
        if(transform.position.y > 4.73){
            transform.position = new Vector3(transform.position.x, 4.73f, 0f);
        }
        if(transform.position.y < -4.73){
            transform.position = new Vector3(transform.position.x,-4.73f,0f);
        }
        if(transform.position.x <= -8.6){
            transform.position = new Vector3(-8.6f,transform.position.y,0f);
        }
        if(transform.position.x >= 8.6){
            transform.position = new Vector3(8.6f,transform.position.y,0f);
        }
    }
    void MovePlayer(){
        movementX = Input.GetAxisRaw("Horizontal");
        posX = transform.position.x + movementX*Time.deltaTime*moveForce;
        movementY = Input.GetAxisRaw("Vertical");
        posY = transform.position.y + movementY*Time.deltaTime*moveForce;
        transform.position =new Vector3(posX,posY,0f);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            BulletMovement.gameOver = true;
        }
    }
}
