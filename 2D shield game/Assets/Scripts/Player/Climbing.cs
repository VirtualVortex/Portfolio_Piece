using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [HideInInspector]
    public bool climbing;

    bool canClimb;
    MasterClass master;

    // Start is called before the first frame update
    void Start()
    {
        master = MasterClass.inst;
    }

    // Update is called once per frame
    void Update()
    {
        //Start climbing when pressing either button.
        if (canClimb && Input.GetKey(KeyCode.W) || canClimb && Input.GetKey(KeyCode.S))
            climbing = true;
        else if (!canClimb)
            climbing = false;

        //freeze in place when standing still
        if (Input.GetKeyUp(KeyCode.W) && canClimb)
            RBFreezeConstraints();

        if (!canClimb)
            ResetConstraints();
    }

    void RBFreezeConstraints()
    {
        master.rb.gravityScale = 0;
        master.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        master.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void ResetConstraints()
    {
        master.rb.gravityScale = 1;
        master.rb.constraints = RigidbodyConstraints2D.None;
        master.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Climable"))
        {
            canClimb = true;
            RBFreezeConstraints();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("Climable"))
            canClimb = false;
    }
}
