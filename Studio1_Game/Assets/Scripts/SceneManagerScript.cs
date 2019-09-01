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
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Cutscene_Scene")
        {
            vidTimer -= Time.deltaTime;
        }

        if (vidTimer <= 0f)
        {
            LoadFirstLevel();
        }
        print(vidTimer);
    }
    public void LoadCutscene()
    {
        SceneManager.LoadScene("Cutscene_Scene");
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
}
