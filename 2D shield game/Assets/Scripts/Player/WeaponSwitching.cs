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

    // Start is called before the first frame update
    void Start()
    {
        WeaponPicker(0);
        lr = GetComponent<LineRenderer>();
        master = MasterClass.inst;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, master.player.transform.position + new Vector3(0,0,1));
        lr.SetPosition(1, weapons[(int)i].transform.position);

        float scrollData = Input.mouseScrollDelta.y * sensitivty;
        if (scrollData != 0.0f && !paused)
            WeaponPicker(scrollData);
    }

    public void WeaponPicker(float scrolldata)
    {
        i += scrolldata;
        i = Mathf.RoundToInt(i);
        Debug.Log(i);

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

    public void EnableClicker()
    {
        for (int j = 0; j < weapons.Length; j++)
        {
            if (j == 3)
            {
                weapons[3].SetActive(true);
                i = 3;
            }

            if (j != 3)
                weapons[j].SetActive(false);
        }
    }

    public void UnenableClicker()
    {
        for (int j = 0; j < weapons.Length; j++)
        {
            if (j == 3)
            {
                weapons[3].SetActive(false);
                i = 3;
            }
        }
    }
}
