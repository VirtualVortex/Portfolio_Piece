using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    [SerializeField , Header("Settings")]
    GameObject energyball;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    Transform raycastPos;
    [SerializeField, Header("Particles")]
    ParticleSystem ps;
    [SerializeField]
    LayerMask layer;

    GameObject player;
    int i;
    float amount;

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

        if (dist < 6 && Time.time > timer && !isStunned)
            behvaiour(States.Attack);
            

        if (!isStunned && dist > 6 )
            behvaiour(States.Idle);

        RaycastHit2D hit = Physics2D.Raycast(raycastPos.position, -raycastPos.up);
        RaycastHit2D groundDetection = Physics2D.Raycast(transform.position, -raycastPos.up, Mathf.Infinity, layer);

        //Rotate when detecting edge
        if (hit.distance > 5 && groundDetection.distance < 5)
            if (transform.eulerAngles.y == 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (transform.eulerAngles.y == 180)
                transform.rotation = Quaternion.Euler(0, 0, 0);

        //Stop moving when falling
        if (groundDetection.distance > 2)
        {
            rb.velocity = -transform.up;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (isStunned && Time.time > timer)
            behvaiour(States.Stunned);
        else if (isStunned && Time.time < timer)
            isStunned = false;

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
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        GameObject inst = null;
        timer = Time.time + coolDown;
        if(i == 0)
            am.PlayOnce(audioSource, attacking);

        //Spawning objects and accessing pooling manager
        for (int i = 0; i < 100; i++)
        {
            if (amount < ObjectPooling.inst.amount)
            {
                inst = Instantiate(energyball, transform.position - transform.forward, Quaternion.identity);
                BallDirection(inst);
                amount++;
            }
            else
                BallDirection(ObjectPooling.inst.RemoveObject());
        }
        
        anim.SetBool("canAttack", false);
    }
    
    //Move the entity from left to right
    public override void Move()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.SetBool("canAttack", false);
        rb.velocity = transform.right;
    }

    //Freezes the enetiy in place
    public override void Stunned()
    {
        isStunned = true;
        ps.Play();
        base.Stunned();
    }
    
    //Setting direction of the energy ball
    void BallDirection(GameObject ball)
    {
        ball.transform.position = transform.position;
        rb.velocity = Vector2.zero;
        Vector2 dir = player.transform.position - transform.position;
        dir.y += Random.Range(-5, 5);
        dir.x += Random.Range(-5, 5);
        ball.GetComponent<Rigidbody2D>().AddForce(dir * projectileSpeed, ForceMode2D.Impulse);
    }
}
