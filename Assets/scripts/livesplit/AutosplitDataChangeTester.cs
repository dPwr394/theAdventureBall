using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutosplitDataChangeTester : MonoBehaviour
{
    public bool isLoading = false;

    public string gameState = null;

    public bool isInLevel = false;

    public int levelIndex = -1;

    public float attemptTime = -1;
    public float attempts = -1;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        isLoading = LSData.isLoadingScene;
        gameState = LSData.gameState;
        isInLevel = LSData.isInLevel;
        levelIndex = LSData.levelIndex;
        attempts = LSData.attempts;
    }
}
