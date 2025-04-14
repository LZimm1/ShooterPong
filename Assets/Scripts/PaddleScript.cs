using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mybody;
    [SerializeField]
    private float moveSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        mybody.velocity = new Vector3(0f, moveSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 4){
            transform.position = new Vector3(transform.position.x, 4f, 0f);
            mybody.velocity = new Vector3(mybody.velocity.x, -mybody.velocity.y,0f);
        }
        if(transform.position.y < -4){
            transform.position = new Vector3(transform.position.x,-4f,0f);
            mybody.velocity = new Vector3(mybody.velocity.x,-mybody.velocity.y,0f);
        }
    }

}
