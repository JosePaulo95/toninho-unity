using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3[] pos;
    public GameObject[] prefab;
    public int amountEnemies = 10;
    public float timeOfMovement = 3.0f;
    private int enemies = 0;
    private float timeRespawEnemy = 4f;
    

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void begin (){
        InvokeRepeating("Spawn", 0f, 1.5f);
    }

    void Spawn(){
        Vector3 position = new Vector3(Random.Range(0, 6), 0, 0);
        int enemyIndex = Random.Range(0, prefab.Length);
        Quaternion rotation = Quaternion.identity;
        GameObject instance = Instantiate(prefab[enemyIndex], transform, false);
        instance.transform.localPosition = position;
        instance.transform.localRotation = rotation;
        if(enemies < amountEnemies) 
        {
            enemies++;

        } else {
            enemies = 0;
            if (timeOfMovement > 0.5f)
            {
                timeOfMovement -= 0.5f;
                timeRespawEnemy -= 0.2f;
            }
            else {
                if (timeOfMovement > 0.1)
                {
                    timeOfMovement -= 0.1f;
                }
            }
        }
    }
}
