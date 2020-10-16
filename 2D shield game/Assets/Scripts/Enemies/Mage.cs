using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    [SerializeField]
    GameObject energyball;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    Transform raycastPos;

    GameObject player;
    bool runAction;
    int i;
    bool isStunned;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        timer = Time.time + coolDown;
        behvaiour(States.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (dist < 6 && Time.time > timer)
            behvaiour(States.Attack);
        else if(!isStunned)
            behvaiour(States.Idle);

        RaycastHit2D hit = Physics2D.Raycast(raycastPos.position, -raycastPos.up);

        if (hit.distance > 5)
            if (transform.eulerAngles.y == 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (transform.eulerAngles.y == 180)
                transform.rotation = Quaternion.Euler(0, 0, 0);

        if (isStunned && Time.time > timer)
            behvaiour(States.Idle);

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

    void Attack()
    {
        timer = Time.time + coolDown;
        for (int i = 0; i < 100; i++)
        {
            rb.velocity = Vector2.zero;
            Vector2 dir = player.transform.position - transform.position;
            dir.x += Random.Range(-5, 5);
            GameObject inst = Instantiate(energyball, transform.position - transform.forward, Quaternion.identity);
            inst.GetComponent<Rigidbody2D>().AddForce(dir * projectileSpeed, ForceMode2D.Impulse);
            Destroy(inst, 5);
        }
    }

    public override void Move()
    {
        anim.SetBool("canAttack", false);
        rb.velocity = transform.right;

        
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
