using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebat : Enemy
{
    GameObject player;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log(dist);
    }

    public override void behvaiour(States state)
    {
        switch (state)
        {
            case States.Idle:
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
        am.Animation("Eyebat_Idle");
    }

    public override void Move()
    {
        am.Animation("Eyebat_Move");
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
