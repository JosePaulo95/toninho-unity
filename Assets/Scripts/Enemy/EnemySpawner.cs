using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3[] pos;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        Vector3 position = new Vector3(Random.Range(0, 6), 0, 0);
        Quaternion rotation = Quaternion.identity;
        GameObject instance = Instantiate(prefab, transform, false);
        instance.transform.localPosition = position;
        instance.transform.localRotation = rotation;
    }
}
