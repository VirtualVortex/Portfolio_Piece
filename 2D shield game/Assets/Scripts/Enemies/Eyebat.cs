﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebat : Enemy
{
    

    GameObject player;
    bool runAction;
    float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        timer = Time.time + coolDown;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        
        if (dist < 8 && Time.time > timer)
            behvaiour(States.Attack);
    }

    public override void behvaiour(States state)
    {
        switch (state)
        {
            case States.Idle:
                runAction = false;
                Idle();
                break;
            case States.Attack:
                Move();
                break;
            default:
                Idle();
                break;
        }
    }

    public override void Idle()
    {
        Debug.Log("Idle");
        am.Animation("Eyebat_Idle");
    }

    public override void Move()
    {
        Debug.Log("Move");
        am.Animation("Eyebat_Move");
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        timer = Time.time + coolDown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Shield"))
        {
            rb.velocity = Vector2.zero;
            behvaiour(States.Idle);
        }
    }
}
