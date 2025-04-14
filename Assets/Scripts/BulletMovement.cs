using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D mybody;
    public static bool gameOver = false;
    bool lethal = false;
    public float timer = 0;
    public static int bulletsHit;
    public AudioSource bounceSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= .5){
            lethal = true;
        }
        if(transform.position.y > 5){
            transform.position = new Vector3(transform.position.x, 5f, 0f);
            mybody.velocity = new Vector3(mybody.velocity.x, -mybody.velocity.y,0f);
        }
        if(transform.position.y < -5){
            transform.position = new Vector3(transform.position.x,-5f,0f);
            mybody.velocity = new Vector3(mybody.velocity.x,-mybody.velocity.y,0f);
        }
        if(transform.position.x <= -9){
            Destroy(gameObject);
        }
        if(transform.position.x >= 9){
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Paddle")){
            mybody.velocity = new Vector3(-mybody.velocity.x,mybody.velocity.y,0f);
            bounceSound.Play();
        }
        if(collision.gameObject.CompareTag("Player") && lethal){
            gameOver = true;
        }
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            PlayerMovement.Score += 1;
            bulletsHit += 1;
        }
    }

}