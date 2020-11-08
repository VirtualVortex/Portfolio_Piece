using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton inst;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        //Singleton
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(FindObjectOfType<Singleton>().gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName != SceneManager.GetActiveScene().name)
        {
            SetUp();
            sceneName = SceneManager.GetActiveScene().name;
        }
    }

    IEnumerator SetUp()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
            child.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
            child.gameObject.SetActive(true);
    }
}
