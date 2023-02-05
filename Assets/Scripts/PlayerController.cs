
using System;
using UnityEngine;
using Toninho;

public enum Stance {
    horizontal,
    vertical
}

public class PlayerController : MonoBehaviour
{
    public TicksController refTicker;
    public Animator refAnim;
    public float step;
    public Stance cur_stance;
    public GameObject refColliderContainer;
    public bool input_is_enabled = true;
    GameObject aux;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 input = new Vector2(0,0);
        if(input_is_enabled){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                input.x = 1;
                input.y = 1;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                input.x = 1;
                input.y = -1;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                input.x = -1;
                input.y = 1;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                input.x = -1;
                input.y = -1;
            }
        }

        Vector2 position_pos_move = new Vector2(transform.position.x+input.x, transform.position.y+input.y);

        if(
            input.x!=0 &&
            position_pos_move.x < 4 &&
            position_pos_move.x > -4 &&
            position_pos_move.y < 4.5f &&
            position_pos_move.y > -3
        ){
            transform.Translate(input.x*step, input.y*step, 0);
            refAnim.SetTrigger("go");
            ToggleStance();
        }
    }

    void ToggleStance(){
        if(cur_stance == Stance.horizontal){
            cur_stance = Stance.vertical;
        }else{
            cur_stance = Stance.horizontal;
        }
    }
    void EnableInput(){
        input_is_enabled = true;
    }
    void DestroyAux(){
        Destroy(aux);
        GameEvent.Trigger("EnemyDeath");
    }
    public void triggersEnemyCollision(Collider2D refCollider, string code){
        if(input_is_enabled){
            input_is_enabled = false;
            Invoke("EnableInput", 1.0f);
            Invoke("DestroyAux", 1.0f);
            refAnim.SetTrigger("chute");
            aux = refCollider.gameObject;
            aux.GetComponent<EnemyMove>().step = 0;
        }
        // if(code == "horizontal" && cur_stance == Stance.vertical){
        //     Destroy(refCollider.gameObject);
        // }else if (code == "vertical" && cur_stance == Stance.horizontal){
        //     Destroy(refCollider.gameObject);
        // }else{
        //     Debug.Log("Colidiu mas n pegou "+DateTime.Now.ToString("HH:mm:ss"));
        // }
    }
}
