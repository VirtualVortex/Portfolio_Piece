using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingTimer : MonoBehaviour
{
    [SerializeField]
    float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnqueueObject", time);
    }

    //Add this object to the list after set amount of time
    void EnqueueObject()
    {
        ObjectPooling.inst.AddObject(gameObject);
        gameObject.SetActive(false);
    }
}
