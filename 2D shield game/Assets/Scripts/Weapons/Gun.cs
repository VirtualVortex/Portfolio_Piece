using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField]
    float maxAmmo;

    public float curAmmo;

    // Start is called before the first frame update
    public override void Start()
    {
        curAmmo = maxAmmo;
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
        Vector3 dir = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity);
        curAmmo -= 1;
        Debug.Log(hit.transform.tag);
    }
}
