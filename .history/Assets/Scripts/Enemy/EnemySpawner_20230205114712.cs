using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3[] pos;
    public GameObject prefab;
    public int amountEnemies = 10;
    public float timeOfMovement = 3.0f;
    

    void Start()
    {
        InvokeRepeating("Spawn", 0f, 2f);
    }

    
    void Update()
    {
        
    }

    void Spawn(){
        Vector3 position = new Vector3(Random.Range(0, 6), 0, 0);
        Quaternion rotation = Quaternion.identity;
        GameObject instance = Instantiate(prefab, transform, false);
        instance.transform.localPosition = position;
        instance.transform.localRotation = rotation;
        amountEnemies--;
    }
}
