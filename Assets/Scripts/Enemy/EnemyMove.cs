using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float move_interval;
    public float step;
    public float velocityModule = 1f;

    private EnemySpawner enemySpawerRef;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawerRef = FindObjectOfType<EnemySpawner>();
        InvokeRepeating("Move", enemySpawerRef.timeOfMovement * velocityModule, 
        enemySpawerRef.timeOfMovement * velocityModule);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){
        transform.Translate(0, -step, 0);
    }
}
