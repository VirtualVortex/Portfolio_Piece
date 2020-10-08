using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    [HideInInspector]
    public enum States {Idle, Attack};
    [HideInInspector]
    public States states;
    [HideInInspector]
    Rigidbody2D rb;
    [HideInInspector]
    bool completeAction;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
