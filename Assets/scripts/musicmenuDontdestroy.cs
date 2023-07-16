using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class musicmenuDontdestroy : MonoBehaviour
{
    private int sceneIndex;
    private int previousScene;
    private static musicmenuDontdestroy instance;
    public AudioMixer audioMixer;
    public bool LevelSelector;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousScene = sceneIndex;

        settingsData data = saveSystemSettings.LoadSettings(); //when loading the game, you want to keep recent settings
        audioMixer.SetFloat("MasterVol", data.audioVolume);

    }
    private void Awake()
    {
        if(LevelSelector == false)
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex != previousScene && LevelSelector == false)
        {
            if(sceneIndex == 23 || sceneIndex == 0) //change when adding new levels
            {
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
            previousScene = sceneIndex;
        }
    }
}
