﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    private Transform player_transform;
    Player player_script;

    [SerializeField]
    private float dist;
    [SerializeField]
    private float howclose;
    // Start is called before the first frame update
     void Start()
    {
        player_script = playerObject.GetComponent<Player>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Update()
    {
        // When MainCaracter dies, the game should stop (or not, depend on designer decision). This is only safe cody just in case.  
        if (player_transform != null)
        {
            dist = Vector2.Distance(player_transform.position, transform.position);
            if (dist < howclose)
            {
                Debug.Log("Saque vida");
                player_script.TakeDamage(5);
            }
        }
        
    }
}
