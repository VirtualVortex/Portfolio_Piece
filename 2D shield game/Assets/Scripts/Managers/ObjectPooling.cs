using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling inst;
    public int amount;

    [HideInInspector]
    public Queue<GameObject> objectQueue = new Queue<GameObject>();

    private void Awake()
    {
        //Singleton
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(FindObjectOfType<ObjectPooling>().gameObject);
    }

    public void AddObject(GameObject ball) => objectQueue.Enqueue(ball);

    public GameObject RemoveObject()
    {
        GameObject inst = objectQueue.Dequeue();
        inst.SetActive(true);
        return inst;
    }
}
