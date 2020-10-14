using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    float sensitivty;

    float i;
    LineRenderer lr;
    MasterClass master;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPicker(0);
        lr = GetComponent<LineRenderer>();
        master = MasterClass.inst;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, master.player.transform.position + new Vector3(0,0,1));
        lr.SetPosition(1, weapons[(int)i].transform.position);

        float scrollData = Input.mouseScrollDelta.y * sensitivty;
        if (scrollData != 0.0f)
            WeaponPicker(scrollData);
    }

    void WeaponPicker(float scrolldata)
    {
        i += scrolldata;
        
        if (i <= -1)
            i = 2;
        else if (i >= 3)
            i = 0;
        
        for (int j = 0; j < weapons.Length; j++)
        {
            if (j == i)
            {
                Debug.Log(i);
                weapons[(int)i].SetActive(true);
            }

            if (j != i)
                weapons[j].SetActive(false);
        }
        
    }
}
