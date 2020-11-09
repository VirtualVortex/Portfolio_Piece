using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    Weapon weapon;
    WeaponSwitching ws;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        ws = FindObjectOfType<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            ws.paused = true;
            Time.timeScale = 0;
            weapon = FindObjectOfType<Weapon>();
            weapon.maxDist = 50;
            
        }

        if(ws.paused)
            ws.EnableClicker();
    }

    public void QuitGame() => Application.Quit();

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        ws.paused = false;
        Time.timeScale = 1;
        weapon.maxDist = 2;
        ws.UnenableClicker();
        ws.WeaponPicker(1);
    }
}
