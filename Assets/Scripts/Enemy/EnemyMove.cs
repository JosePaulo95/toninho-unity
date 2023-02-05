using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float move_interval;
    public float step;

    private EnemySpawner enemySpawerRef;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawerRef = FindObjectOfType<EnemySpawner>();
        InvokeRepeating("Move", enemySpawerRef.timeOfMovement, 
        enemySpawerRef.timeOfMovement);
        Debug.Log(enemySpawerRef.timeOfMovement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        transform.Translate(0, -step, 0);
    }
}
