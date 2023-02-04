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
    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        if(inputx > 0){
            input.x = 1;
            input.y = 1;
        }
        if(inputx < 0){
            input.x = -1;
            input.y = 1;
        }
        if(inputy > 0){
            input.x = 1;
            input.y = 1;
        }
        if(inputy < 0){
            input.x = -1;
            input.y = -1;
        }
    }

    public bool hasInput (){
        return input.x != 0 && input.y != 0;
    }
    public Vector2 popInput(){
        Vector2 aux = input;
        clearInput();
        return aux;
    }
    void clearInput (){
        input = new Vector2(0,0);
    }

}
