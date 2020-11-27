using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;

    public float maxDist;

    [HideInInspector]
    public MasterClass master;
    

    // Start is called before the first frame update
    public virtual void Start()
    {
        master = MasterClass.inst;
        player = master.player;
        transform.position = (Vector2)player.transform.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void movement()
    {
        Vector3 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1;
        float dist = Vector2.Distance(mousePos, player.transform.position);

        //Set position of weapon
        if (dist > maxDist)
        {
            Vector3 dir = mousePos - player.transform.position;
            dir *= maxDist / dist;
            transform.position = player.transform.position + dir;
        }
        else 
            transform.position = mousePos;
    }

    private void OnEnable()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
