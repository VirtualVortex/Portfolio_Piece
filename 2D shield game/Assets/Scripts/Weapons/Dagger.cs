using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    [SerializeField]
    float damage;

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

    public override void movement()
    {
        base.movement();
        Vector3 dir = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);

        if (other.tag.Contains("Enemy"))
            other.GetComponent<Health>().ReduceHealth(damage);
    }
}
