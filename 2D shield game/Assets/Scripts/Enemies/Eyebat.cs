using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebat : Enemy
{
    GameObject player;
    bool runAction;
    bool isStunned;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        //timer = Time.time + coolDown;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        
        if (dist < 8 && Time.time > timer)
            behvaiour(States.Attack);
        else if(Time.time < timer && !isStunned)
            behvaiour(States.Idle);
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
                Debug.Log("Attack");
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

    public override void Idle()
    {
        Debug.Log("Idle");
        anim.SetBool("canAttack", false);
    }

    public override void Move()
    {
        Debug.Log("Move");
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        timer = Time.time + coolDown;
    }

    public override void Stunned()
    {
        isStunned = true;
        base.Stunned();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
