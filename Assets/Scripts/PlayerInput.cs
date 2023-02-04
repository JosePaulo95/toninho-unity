using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        input = new Vector2(0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputy = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            input.x = 1;
            input.y = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            input.x = -1;
            input.y = 1;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            input.x = 1;
            input.y = 1;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            input.x = -1;
            input.y = -1;
        }
    }

    public bool hasInput (){
        return input.x != 0 && input.y != 0;
    }
    public Vector2 popInput(){
        Vector2 aux = input;
        //clearInput();
        return aux;
    }
    void clearInput (){
        input = new Vector2(0,0);
    }

}
