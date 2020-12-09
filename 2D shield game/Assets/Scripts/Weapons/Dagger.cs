using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    public float damage;

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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        //Deal damage
        if (other.tag.Contains("Enemy"))
            other.GetComponent<Health>().ReduceHealth(damage);
    }
}
