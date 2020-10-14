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
        DontDestroyOnLoad(this.gameObject);
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

        if (dist < maxDist)
            transform.position = mousePos;
        /*else if (dist > maxDist)
            transform.position = (Vector2)player.transform.position;*/
    }

    private void OnEnable()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
