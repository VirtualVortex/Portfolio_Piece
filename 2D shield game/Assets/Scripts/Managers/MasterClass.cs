using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterClass : MonoBehaviour
{
    public static MasterClass inst;

    [HideInInspector]
    public GameObject player { get; private set; }

    [HideInInspector]
    public Rigidbody2D rb { get; private set; }
    [HideInInspector]
    public SpriteRenderer sr { get; private set; }
    [HideInInspector]
    public PlayerMovement pm { get; private set; }
    [HideInInspector]
    public Climbing climbing { get; private set; }
    [SerializeField]
    public Health health { get; private set; }
    

    private void Awake()
    {
        inst = this;
        SetUp();
    }
    
    //Set up properties
    void SetUp()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        sr = player.GetComponent<SpriteRenderer>();
        pm = player.GetComponent<PlayerMovement>();
        climbing = player.GetComponent<Climbing>();
        health = player.GetComponent<Health>();
    }
}
