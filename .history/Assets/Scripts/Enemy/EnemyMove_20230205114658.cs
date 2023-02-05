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
        InvokeRepeating("Move", move_interval, move_interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        transform.Translate(0, -step, 0);
        Debug.Log(enemySpawerRef.amountEnemies);
    }
}
