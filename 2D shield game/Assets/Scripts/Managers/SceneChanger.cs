using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float currentScene;
    public static SceneChanger inst;

    int i;

    private void Awake()
    {
        inst = this;
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

    public void ChangeScene()
    {
        i += 1;
        SceneManager.LoadScene(i);
    }

    void GoToBegining()
    {
        SceneManager.LoadScene(0);
    } 
}
