using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    Transform player;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = player.position.y + 3;
        cam.position = pos;
    }
}
