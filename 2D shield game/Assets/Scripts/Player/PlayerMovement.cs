using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    MasterClass master;

    // Start is called before the first frame update
    void Start()
    {
        master = MasterClass.inst;
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 pos = transform.right * x;
        pos *= speed;
        pos.y = master.rb.velocity.y;

        if (x > 0)
            master.sr.flipX = false;
        else if (x < 0)
            master.sr.flipX = true;

        master.rb.velocity = pos;
    }
}
