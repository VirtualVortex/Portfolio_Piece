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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add object to pool queue
        if (collision.transform.tag.Contains("Damage"))
        {
            ObjectPooling.inst.AddObject(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
