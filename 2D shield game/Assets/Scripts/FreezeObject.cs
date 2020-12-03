using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Freeze"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Freeze"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
