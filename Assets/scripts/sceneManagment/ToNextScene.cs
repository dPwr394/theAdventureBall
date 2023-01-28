using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour {

	private int nextSceneToLoad;

	private void Start()
	{
		nextSceneToLoad = SceneManager.GetActiveScene ().buildIndex + 1;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene (nextSceneToLoad);

		if (nextSceneToLoad == 22) //YOU NEED TO CHANGE IT IF NEW LEVELS ARE AVAILABLE
        {
			LSData.isInLevel = false;
			LSData.levelIndex = -1;
			LSData.gameState = "Victory";
        }
        else
		{
			LSData.levelIndex += 1; 
			LSData.gameState = "Exiting Level"; 
		}
	}
}
