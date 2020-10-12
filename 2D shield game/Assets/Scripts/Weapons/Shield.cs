using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        movement();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Enemy"))
        {
            Vector2 inDirection = collision.transform.GetComponent<Rigidbody2D>().velocity;
            Vector2 inNormal = (inDirection - collision.contacts[0].point).normalized;
            
            collision.transform.position = Vector2.Reflect(inDirection, inNormal);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag.Contains("Damage"))
        {
            Destroy(collision.gameObject);
        }
    }
}
