using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class controlsManager : MonoBehaviour
{
    public int sceneIndex;
    private int previousScene;
    private static controlsManager instance;

    public bool enableMouse = false;
    public bool enableKeyboard = true;
  //  public GameObject player;
    public GameObject ControlsGuide_keys;
    public GameObject ControlsGuide;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousScene = sceneIndex;

     //   if (sceneIndex >= 1)
      //  {
      //      player = GameObject.FindGameObjectWithTag("Player");
      //      player.GetComponent<PlayerCon>();
       // }
    }
    private void Awake()
    {

       // DontDestroyOnLoad(this);

       // if (instance == null)
      //  {
      //      instance = this;
      //  }
      //  else
      //  {
      //      Destroy(this.gameObject);
      //  }

        settingsData data = saveSystemSettings.LoadSettings(); //when loading the game, you want to keep recent settings

        enableMouse = data.mouseOn;
        enableKeyboard = data.keyboardOn;


    }
    // Update is called once per frame
    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;


     //   if (sceneIndex != previousScene && sceneIndex >= 1)
    //    {
   //         player = GameObject.FindGameObjectWithTag("Player");
   //         player.GetComponent<PlayerCon>();
//
  //          previousScene = sceneIndex;
  //      }
//
  //      if (enableKeyboard && sceneIndex >= 1) //if not in menus, and keyboard is checked in the setting menu, disable mouse and enable keyboard.
  //      {
  //          player.GetComponent<PlayerCon>().enableKeyboard = true;
 //           player.GetComponent<PlayerCon>().enableMouse = false;
 //       }
 //       if  (enableKeyboard == false && sceneIndex >= 1)//opposite
  //      {
  //          player.GetComponent<PlayerCon>().enableKeyboard = false;
    //        player.GetComponent<PlayerCon>().enableMouse = true;
     //   }
    //    if (enableMouse && sceneIndex >= 1)
    //    {
   //         player.GetComponent<PlayerCon>().enableMouse = true;
   //         player.GetComponent<PlayerCon>().enableKeyboard = false;
  //          }
  //      if (enableMouse == false && sceneIndex >= 1)
  //      {
 //           player.GetComponent<PlayerCon>().enableMouse = false;
 //           player.GetComponent<PlayerCon>().enableKeyboard = true;
//            }
        
        if(enableMouse && sceneIndex == 2) //changes hints in sp_basics
        {
            ControlsGuide = GameObject.Find("ControlsGuide");
            ControlsGuide.GetComponent<TMP_Text>().text = "Directions";

            ControlsGuide_keys = GameObject.Find("ControlsGuide_keys");
            ControlsGuide_keys.GetComponent<TMP_Text>().text = "MOUSE1";
        }

    }
}
