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

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
