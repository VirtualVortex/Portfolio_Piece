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
            Destroy(FindObjectOfType<AudioManager>().gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject ball) => objectQueue.Enqueue(ball);

    public GameObject RemoveObject() => objectQueue.Dequeue();
}
