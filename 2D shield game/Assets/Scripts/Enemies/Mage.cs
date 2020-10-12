using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    [SerializeField]
    GameObject energyball;

    GameObject player;
    bool runAction;
    float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        timer = Time.time + coolDown;
        behvaiour(States.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (dist < 15 && Time.time > timer)
            behvaiour(States.Attack);
    }

    public override void behvaiour(States state)
    {
        switch (state)
        {
            case States.Idle:
                runAction = false;
                Move();
                break;
            case States.Attack:
                Attack();
                break;
            default:
                Idle();
                break;
        }
    }

    void Attack()
    {
        am.Animation("Mage_Attack");
        Vector2 dir = player.transform.position - transform.position;
        GameObject inst = Instantiate(energyball, transform.position, Quaternion.identity);
        inst.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        //Add inst to pooling manager
    }

    public override void Move()
    {
        Debug.Log("Move");
        am.Animation("Mage_Idle");
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        timer = Time.time + coolDown;
    }
    
}
