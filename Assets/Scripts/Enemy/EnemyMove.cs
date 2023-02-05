using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float move_interval;
    public float step;

    private FiniteEnemySpawner enemySpawerRef;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawerRef = FindObjectOfType<FiniteEnemySpawner>();
        InvokeRepeating("Move", enemySpawerRef.enemy_speed, enemySpawerRef.enemy_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        transform.Translate(0, -step, 0);
    }
}
