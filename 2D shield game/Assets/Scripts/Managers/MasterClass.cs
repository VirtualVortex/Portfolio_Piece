using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClass : MonoBehaviour
{
    public static MasterClass inst;

    GameObject player;

    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public SpriteRenderer sr;

    private void Awake() => inst = this;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        sr = player.GetComponent<SpriteRenderer>();
    }
}
