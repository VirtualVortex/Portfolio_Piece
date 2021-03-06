﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebat : Enemy
{
    [SerializeField, Header("Particles")]
    ParticleSystem ps;

    GameObject player;
    SpriteRenderer sr;
    DealDamage dd;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
        dd = GetComponent<DealDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (dist < 8 && Time.time > timer)
            behvaiour(States.Attack);
        else if (Time.time < timer && !isStunned)
            behvaiour(States.Idle);

        FlipSprite();
    }

    //Switch between different behaviours
    public override void behvaiour(States state)
    {
        switch (state)
        {
            case States.Idle:
                runAction = false;
                Idle();
                break;
            case States.Attack:
                anim.SetBool("canAttack", true);
                break;
            case States.Stunned:
                Stunned();
                break;
            default:
                Idle();
                break;
        }
    }

    //Play Idle animation
    public override void Idle()
    {
        anim.SetBool("canAttack", false);
        dd.enabled = false;
    }

    //Move in direction of player
    public override void Move()
    {
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        am.PlayOnce(audioSource, attacking);
        timer = Time.time + coolDown;
        anim.SetBool("canAttack", false);
        dd.enabled = true;
    }

    //Play stunned animation and vfx
    public override void Stunned()
    {
        timer += coolDown;
        isStunned = true;
        ps.Play();
        dd.enabled = false;
        base.Stunned();
    }

    //Flip the sprite horizontally based on movement direction
    void FlipSprite()
    {
        Vector3 dir = player.transform.position - transform.position;

        if (dir.normalized.x > 0)
            sr.flipX = true;
        else if (dir.normalized.x < 0)
            sr.flipX = false;
    }
}
