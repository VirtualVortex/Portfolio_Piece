using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [HideInInspector]
    public bool climbing;

    bool canClimb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");

        if (canClimb && Input.GetKeyDown(KeyCode.W))
            climbing = true;
        else if (!canClimb)
            climbing = false;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Climable"))
            canClimb = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("Climable"))
            canClimb = false;
    }
}
