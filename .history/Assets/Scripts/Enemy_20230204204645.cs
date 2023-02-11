using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    private PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6)
        {
            player.AttackPlayer();
        }
    }
}
