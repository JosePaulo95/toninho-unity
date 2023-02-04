using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private int ticks = 0, previous_tick = 0;
    public float tick_duration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Ticks", 0, tick_duration);
    }
    void Ticks () {
        ticks++;
    }
    // Update is called once per frame
    void Update()
    {
        if(ticks > previous_tick){
            previous_tick=ticks;
            transform.Rotate(0, 0, 90);
        }

        float horizontal = Input.GetAxis("Horizontal");
        //float horizontal = Input.GetAxis("Horizontal");
        if(horizontal > 0){
            
        }
            
    }
}
