using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string currentScene;
    public Vector2 startPos;
    public static SceneChanger inst;

    int i;

    private void Awake()
    {
        //Singleton
        if(inst == null)
            inst = this;
        else if(inst != this)
            Destroy(FindObjectOfType<SceneChanger>().gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void ChangeScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void GoToBegining()
    {
        SceneManager.LoadScene(currentScene);
        MasterClass.inst.player.transform.position = startPos;
    } 
}
