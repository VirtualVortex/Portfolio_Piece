﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField]
    float maxAmmo;

    public float damage;

    LineRenderer lr;
    float curAmmo;
    RaycastHit2D hit;

    // Start is called before the first frame update
    public override void Start()
    {
        curAmmo = maxAmmo;
        lr = GetComponent<LineRenderer>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity);

        LaserPointer();
        movement();

        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    public override void movement()
    {
        base.movement();
        Vector3 dir = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void Fire()
    {
        hit.transform.GetComponent<Health>().ReduceHealth(damage);
        curAmmo -= 1;
    }

    void LaserPointer()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, hit.point);
    }
}
