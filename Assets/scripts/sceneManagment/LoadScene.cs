using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {



	public void SceneLoader (int SceneIndex) {
		SceneManager.LoadScene(SceneIndex);
		Time.timeScale = 1;

		if (SceneIndex == 22) //YOU NEED TO CHANGE IT IF NEW LEVELS ARE AVAILABLE
		{
			LSData.isInLevel = false;
			LSData.levelIndex = -1;
		}

		if (SceneIndex == 1) //YOU NEED TO CHANGE IT IF THE LEVEL SELECTOR HAS MOVED
		{
			LSData.isInLevel = false;
			LSData.gameState = "Level Select";
			LSData.levelIndex = -1;
			LSData.attemptTime = 0f;
		}

		if (SceneIndex == 0)
		{
			LSData.isInLevel = false;
			LSData.gameState = "Main Menu";
			LSData.levelIndex = -1;
			LSData.attemptTime = 0f;
		}

		if (SceneIndex >= 2 && SceneIndex != 22) //YOU NEED TO CHANGE IT IF THE LEVEL SELECTOR HAS MOVED
		{
			LSData.isInLevel = true;
			LSData.levelIndex = 1;
			LSData.gameState = "Playing";
		}
	}


}
