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
        
    }
    void Ticks () {
        if(refInput.hasInput()){
            Vector2 input = refInput.popInput();
            transform.Translate(input.x*step, input.y*step, 0);
            toggleInstance();
        }
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
