using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Debug.Log("Teste");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 6)
        {
            Debug.Log("Teste");
            player.AttackPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Teste 1");
        if(other.gameObject.layer == 6)
        {
            Debug.Log("Teste");
            player.AttackPlayer();
        }
    }
}
