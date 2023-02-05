using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private PlayerController refPlayerController;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        refPlayerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"){
            refPlayerController.triggersEnemyCollision(collision, name);
        }
    }
}
