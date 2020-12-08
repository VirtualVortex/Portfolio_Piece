using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject[] weapons;
    [SerializeField]
    float sensitivty;

    [HideInInspector]
    public float i;

    LineRenderer lr;
    MasterClass master;

    [HideInInspector]
    public bool paused;

    int clickerNum;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPicker(0);
        lr = GetComponent<LineRenderer>();
        master = MasterClass.inst;
        Cursor.visible = false;
        clickerNum = weapons.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, master.player.transform.position + new Vector3(0,0,1));
        lr.SetPosition(1, weapons[(int)i].transform.position);

        float scrollData = Input.mouseScrollDelta.y * sensitivty;
        if (scrollData != 0.0f && !paused && weapons.Length > 1)
            WeaponPicker(scrollData);
    }

    //Enable the weapon that's been picked.
    public void WeaponPicker(float scrolldata)
    {
        i += scrolldata;
        i = Mathf.RoundToInt(i);

        if (i <= -1)
            i = (weapons.Length - 2);
        else if (i >= weapons.Length - 1)
            i = 0;
        
        for (int j = 0; j < weapons.Length - 1; j++)
        {
            if (j == i)
                weapons[(int)i].SetActive(true);

            if (j != i)
                weapons[j].SetActive(false);
        }
        
    }

    //Only enable the clicker when called.
    public void EnableClicker()
    {
        for (int j = 0; j < weapons.Length; j++)
        {
            if (j == clickerNum)
            {
                weapons[clickerNum].SetActive(true);
                i = clickerNum;
            }

            if (j != clickerNum)
                weapons[j].SetActive(false);
        }
    }

    //Stop the clicker from being accessible
    public void UnenableClicker()
    {
        for (int j = 0; j < weapons.Length; j++)
        {
            if (j == clickerNum)
            {
                weapons[clickerNum].SetActive(false);
                i = clickerNum;
            }
        }
    }
}
