using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float coolDown;

    [Header("Audio")]
    public AudioClip idle;
    public AudioClip attacking;

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

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Shield"))
        {
            behvaiour(States.Stunned);
        }
    }
}
