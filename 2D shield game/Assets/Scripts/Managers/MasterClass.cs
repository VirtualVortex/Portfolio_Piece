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

    string sceneName;

    private void Awake()
    {
        inst = this;
        Singleton();

        SetUp();
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (sceneName != SceneManager.GetActiveScene().name)
        {
            SetUp();
            sceneName = SceneManager.GetActiveScene().name;
        }
    }

    void Singleton()
    {
        //Singleton
        if(inst == null)
            inst = this;
        else if(inst != this)
            Destroy(FindObjectOfType<SceneChanger>().gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

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
