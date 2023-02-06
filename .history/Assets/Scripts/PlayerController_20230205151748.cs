
using System;
using UnityEngine;

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
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                input.x = 1;
                input.y = 1;
                refAnim.SetTrigger("go");
                ToggleStance();
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                input.x = 1;
                input.y = -1;
                refAnim.SetTrigger("go");
                ToggleStance();
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                input.x = -1;
                input.y = 1;
                refAnim.SetTrigger("go");
                ToggleStance();
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
                input.x = -1;
                input.y = -1;
                refAnim.SetTrigger("go");
                ToggleStance();
            }
        }

        transform.Translate(input.x*step, input.y*step, 0);
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
