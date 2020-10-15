using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    Transform cam;
    Transform player;
    MasterClass master;
    Vector3 pos;

    private void Awake()
    {
        master = MasterClass.inst;
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = master.player.transform;
        pos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = player.position.y + 3;
        cam.position = pos;
    }
}
