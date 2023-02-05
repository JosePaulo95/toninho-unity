using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TicksController refTicker;
    public Animator refAnim;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 input = new Vector2(0,0);
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            input.x = 1;
            input.y = 1;
            refAnim.SetTrigger("go");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            input.x = 1;
            input.y = -1;
            refAnim.SetTrigger("go");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            input.x = -1;
            input.y = 1;
            refAnim.SetTrigger("go");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            input.x = -1;
            input.y = -1;
            refAnim.SetTrigger("go");
        }

        transform.Translate(input.x*step, input.y*step, 0);
    }
}
