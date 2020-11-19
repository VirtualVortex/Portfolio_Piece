using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField]
    string scene;

    SceneChanger sc;
    // Start is called before the first frame update
    void Start() => sc = SceneChanger.inst;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Change scene when colliding with it
        if (collision.name.Contains("Player"))
            sc.ChangeScene(scene);
    }
}
