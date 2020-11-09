using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControls : MonoBehaviour
{
    Transform cam;
    Transform player;
    MasterClass master;
    Vector3 pos;
    string sceneName;

    public static CameraControls inst;

    private void Awake()
    {
        //Singleton
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(FindObjectOfType<CameraControls>().gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName != SceneManager.GetActiveScene().name)
        {
            SetUp();
            sceneName = SceneManager.GetActiveScene().name;
        }
        
        pos.y = player.position.y + 3;
        cam.position = pos;
    }
    
    public void SetUp()
    {
        master = MasterClass.inst;
        cam = FindObjectOfType<Camera>().transform;

        player = master.player.transform;
        pos = cam.position;
    }
    
}
