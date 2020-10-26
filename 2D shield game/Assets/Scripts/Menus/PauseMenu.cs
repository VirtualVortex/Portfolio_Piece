﻿using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            ws.i = 3;
            Time.timeScale = 0;
            weapon = FindObjectOfType<Weapon>();
            weapon.maxDist = 50;
            
        }
    }

    public void QuitGame() => Application.Quit();

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        weapon.maxDist = 2;
        ws.i = 0;
    }
}
