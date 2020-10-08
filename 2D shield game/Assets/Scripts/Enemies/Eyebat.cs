using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebat : Enemy
{
    DealDamage dd;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        dd = GetComponent<DealDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
