using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class LSData
{
    /// <summary>
    /// True if the game is in a load screen.
    /// </summary>
    public static bool isLoadingScene = false;

    /// <summary>
    /// The current state of the game in human readable format.
    /// 
    /// Possible values are: 
    /// "Playing", "Crashed", "Replay", "Victory", "Exiting Level", "Level Select", 
    /// "Cinematic", "Main Menu", "Loading", or null.
    /// </summary>
    public static string gameState = null; 

    /// <summary>
    /// True if the player is in a level, false otherwise.
    /// </summary>
    public static bool isInLevel = false;

    /// <summary>
    /// The index of the level the player is in. -1 if not in a level.
    /// </summary>
    public static int levelIndex = -1;

    /// <summary>
    /// The in-game time for the current attempt on this level.
    /// </summary>
    public static float attemptTime = 0f;

    public static int attempts = 0;

}

