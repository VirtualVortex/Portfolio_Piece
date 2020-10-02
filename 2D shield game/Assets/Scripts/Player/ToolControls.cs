using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControls : MonoBehaviour
{
    public Transform tool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(Input.mousePosition.y, Input.mousePosition.x) * Mathf.Rad2Deg;
        tool.rotation = Quaternion.Euler(0,0,angle);
    }
}
