using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public float maxDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void movement()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(mousePos, player.transform.position);

        if (dist < maxDist)
            transform.position = mousePos;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
