using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    Transform player;

    float i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData = Input.mouseScrollDelta.y;
        if (scrollData != 0.0f)
            WeaponPicker(scrollData);
    }

    void WeaponPicker(float scrollData)
    {
        i += scrollData;
        for (int j = 0; j < weapons.Length + 1; j++)
        {
            if (j == i)
                weapons[(int)j - 1].SetActive(true);
            
        }
    }
}
