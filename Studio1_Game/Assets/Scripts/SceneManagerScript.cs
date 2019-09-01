using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    public VideoPlayer vidPlayer;
    float vidTimer = 122f;
    void Update()
    {
        vidTimer -= Time.deltaTime;
        print(vidTimer);
        if (vidTimer <= 0f)
        {
            LoadFirstLevel();
        }
    }
    public void LoadCutscene()
    {
        SceneManager.LoadScene("Cutscene_Scene");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("First Level");
    }
}
