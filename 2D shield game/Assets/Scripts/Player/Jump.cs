using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    MasterClass master;

    // Start is called before the first frame update
    void Start()
    {
        master = MasterClass.inst;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            master.rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
