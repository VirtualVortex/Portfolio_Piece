using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Weapon
{
    [SerializeField]
    float maxAmmo;
    [SerializeField]
    LayerMask layer;

    public float damage;

    Image ammoBar;
    LineRenderer lr;
    float curAmmo;
    RaycastHit2D hit;
    float x;
    
    // Start is called before the first frame update
    public override void Start()
    {
        curAmmo = maxAmmo;
        lr = GetComponent<LineRenderer>();

        //find the ammo bar
        ammoBar = GameObject.Find("Canvas").transform.Find("Background").transform.Find("AmmoBar").GetComponent<Image>();
        x = 1;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, layer);

        LaserPointer();
        movement();

        if (Input.GetMouseButtonDown(0) && curAmmo > 0)
            Fire();
    }

    //Move like other weapons while rotating away from the player
    public override void movement()
    {
        //reduce health when hit
        base.movement();
        Vector3 dir = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void Fire()
    {
        if(hit.transform.GetComponent<Health>())
            hit.transform.GetComponent<Health>().ReduceHealth(damage);
        curAmmo -= 1;

        x = Mathf.InverseLerp(0, maxAmmo, curAmmo);
        ammoBar.fillAmount = x;
    }

    void LaserPointer()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, hit.point);
    }
}
