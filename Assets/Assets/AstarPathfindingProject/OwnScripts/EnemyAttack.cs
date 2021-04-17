﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private GameObject playerObject;
    private Transform player_transform;
    Player player_script;
    Defence player_defence;
    [SerializeField]
    private float dist;
    [SerializeField]
    private float howclose;
    [SerializeField]
    private float coolDown = 3;
    private float coolDownTimer = 0;
    enemy_animator animations;
    // Start is called before the first frame update
    void Start()
    {
        // Need some script of the main character to know things such as location, defenceMode. 

        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        animations = gameObject.GetComponent<enemy_animator>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player_script = playerObject.GetComponent<Player>();
        player_defence = player_script.GetComponent<Defence>();


    }

// Update is called once per frame
public void attack()
    {

        // Attack if in range
        dist = Vector2.Distance(player_transform.position, transform.position);
        if (dist < howclose && (!player_defence.defenseActivated() ||
           (player_defence.defenseSize() < 0 && ((player_transform.position.x - transform.position.x < 0)) || //Attack from behind
           (player_defence.defenseSize() > 0 && (player_transform.position.x - transform.position.x > 0)))))
        {
            if (coolDownTimer == 0f)
            {
                animations.StartAttacking();
                player_script.TakeDamage(5);

                coolDownTimer = coolDown;
            }
        }
    }


    public void Update()

    {
        // When MainCaracter dies, the game should stop (or not, depend on designer decision). This is only safe code just in case.  
        

            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }


    }

    
}

