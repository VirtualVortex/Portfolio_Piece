using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    SceneChanger sc;
    // Start is called before the first frame update
    void Start() => sc = SceneChanger.inst;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
            sc.ChangeScene();
    }
}
