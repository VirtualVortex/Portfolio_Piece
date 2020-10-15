using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public Vector3 pos;

    MasterClass master;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        master = MasterClass.inst;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        pos = transform.right * x;
        pos *= speed;
        pos.y = master.rb.velocity.y;

        if (master.climbing.climbing)
            pos = transform.right * x + transform.up * y * speed;

        anim.SetFloat("isWalking", Mathf.Abs(x));

        if (x > 0)
            master.sr.flipX = false;
        else if (x < 0)
            master.sr.flipX = true;

        master.rb.velocity = pos;
    }
}
