using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
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

        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    public override void movement()
    {
        base.movement();

        float angle = Mathf.Atan2(player.transform.position.x, transform.position.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.EulerAngles(0,0,angle * 0.1f);
    }

    void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity);

        Debug.Log(hit.transform.tag);
    }
}
