﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControls : MonoBehaviour
{
    [SerializeField]
    float maxDist;
    public Transform tool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void movement(Vector3 playerPos)
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(mousePos, playerPos);

        if (dist < maxDist)
            tool.position = mousePos;

    }
}
