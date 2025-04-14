using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    private float posX,posY;
    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemies(){
        while(true){
            yield return new WaitForSeconds(1);
            GameObject enemyRef = Instantiate(enemy);
            posY = Random.Range(0,2);
            if(posY % 2 == 1){
                posY = -4.8f;
            }
            else{
                posY = 4.8f;
            }
            posX = Random.Range(-8,8);
            enemyRef.transform.position = new Vector3(posX,posY,0f);
        }
    }
}
