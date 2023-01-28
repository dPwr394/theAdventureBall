using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LSscenemanager : MonoBehaviour
{
    public static bool isloading;
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex >= 2 && sceneIndex != 22)
        {
            LSData.isInLevel = true;
            LSData.levelIndex = 1;
            LSData.gameState = "Playing";
        }
    }

    // Update is called once per frame
    void Update()
    {

        isloading = SceneManager.GetActiveScene().isLoaded;
        isloading = LSData.isLoadingScene;
        if (isloading)
        {
            LSData.gameState = "Loading";
        }
        
        if(sceneIndex == 0)
        {
            LSData.isInLevel = false;
            LSData.gameState = "Main Menu";
            LSData.levelIndex = -1;
            LSData.attemptTime = 0f;
        }

        if (sceneIndex == 1)
        {
            LSData.isInLevel = false;
            LSData.gameState = "Level Select";
            LSData.levelIndex = -1;
            LSData.attemptTime = 0f;
        }


    }
}
