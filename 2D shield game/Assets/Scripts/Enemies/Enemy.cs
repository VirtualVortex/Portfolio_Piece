using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Animator anim;

    [HideInInspector]
    public enum States {Idle, Attack};
    [HideInInspector]
    public States states;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public AnimationManager am;
    [HideInInspector]
    bool completeAction;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = AnimationManager.animManager;
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
}
