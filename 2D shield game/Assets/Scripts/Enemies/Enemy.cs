﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, coolDown;

    [Header("Audio")]
    public AudioClip idle, attacking;

    [HideInInspector]
    public enum States {Idle, Attack, Stunned};
    [HideInInspector]
    public States states;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    bool completeAction;
    [HideInInspector]
    public float timer;
    [HideInInspector]
    public AudioManager am;
    [HideInInspector]
    public AudioSource audioSource;
    [HideInInspector]
    public bool runAction, isStunned;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        am = AudioManager.inst;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void behvaiour(States state)
    {
        switch (state)
        {
            case States.Idle:
                break;
            case States.Attack:
                break;
            default:
                break;
        }
    }

    public virtual void Idle()
    {
    }

    public virtual void Move()
    {
    }

    public virtual void Stunned()
    {
        timer = Time.time + 5;
        rb.velocity = Vector2.zero;
    }

    //Stun when colliding with shield
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Shield"))
            behvaiour(States.Stunned);
    }

    //Destroy when colliding with the cage
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Cage"))
            Destroy(gameObject);
    }
}
