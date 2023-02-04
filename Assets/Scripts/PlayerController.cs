using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stance
{
    Vertical,
    Horizontal
}
public class PlayerController : MonoBehaviour
{
    public Stance playerStance;
    public TicksController refTicker;
    public PlayerInput refInput;
    public Animator refAnim;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        playerStance = Stance.Horizontal;
        InvokeRepeating("Ticks", 0, refTicker.tick_duration);
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

        //Input.GetKeyDown(KeyCode.RightArrow)
        transform.Translate(input.x*step, input.y*step, 0);
        
    }
    void Ticks () {
    }
    void toggleInstance(){
        if(playerStance == Stance.Vertical){
            playerStance = Stance.Horizontal;
        }else{
            playerStance = Stance.Vertical;
        }
        readInstance();
    }

    void readInstance () {
        //transform.rotation = new Vector3(, input.y*step, 0)
    }
}
