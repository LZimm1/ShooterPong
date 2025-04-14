using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static int bulletsShot = 0;
    private float bulletSpeed = 25f;
    private Vector3 mousePos;
    public AudioSource shootSound;
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject crossHair;

    public GameObject bullet;

    public static float velX = 0f;
    public static float velY = 0f;
    private Vector3 difference;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        crossHair.transform.position = new Vector3 (mousePos.x,mousePos.y,0.0f);
        difference =  mousePos -player.transform.position;
        float rotationZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);
        float distance = difference.magnitude;
        Vector2 direction = difference/distance;
        ShootBullet(rotationZ,direction);
    }

    void ShootBullet(float rotationZ, Vector2 direction){
        if(Input.GetMouseButtonDown(0)){
            GameObject bulletRef = Instantiate(bullet);
            bulletRef.transform.position = player.transform.position;
            bulletRef.transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
            bulletRef.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletsShot += 1;
            shootSound.Play();
        }
    }
}
