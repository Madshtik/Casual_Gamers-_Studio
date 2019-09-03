﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    public VideoPlayer vidPlayer;
    float vidTimer = 122f;
    public GameObject pauseMenu;
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "CutScene_Scene")
        {
            vidTimer -= Time.deltaTime;
            if (vidTimer <= 0f || Input.GetKeyDown(KeyCode.Escape))
            {
                LoadFirstLevel();
            }
        }
        Debug.Log(sceneName);
        Debug.Log(vidTimer);
    }
    public void LoadCutscene()
    {
        SceneManager.LoadScene("CutScene_Scene");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("First Level");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene("Second Level");
        }
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Resume()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
