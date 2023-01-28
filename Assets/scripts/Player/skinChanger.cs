using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class skinChanger : MonoBehaviour
{
    public Sprite skinnum2;
    private GameObject ballFace;
    private GameObject eye1;
    private GameObject eye2;
    public int sceneIndex;
    private int previousScene;
    public Sprite skinFace;
    public Sprite defaultSkinFace;
    public Sprite defaulteyes;
    public Sprite NoEyes;
    private bool hideFaceEyes = false;

    private int SameObjects;
    private static skinChanger instance;

    public GameObject button1, button2;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousScene = sceneIndex;

        skinFace = defaultSkinFace;

        if (sceneIndex >= 1)
        {
            ballFace = GameObject.Find("2");
            skinFace = ballFace.GetComponent<SpriteRenderer>().sprite; //without it, when going foward, the player will be with no texture. beacause they didn't change skin the scrip never writes the current sprite.

        }
    }
    private void Awake()
    {
        //   if (sceneIndex == 0)
        //  {
        //      SameObjects = FindObjectsOfType<skinChanger>().Length;
        //      if (SameObjects != 1)
        //      {
        //         Destroy(this.gameObject);
        //    }
        //     else
        //    {
        //        DontDestroyOnLoad(gameObject);
        //    }
        //}

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

    private void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex != previousScene && sceneIndex >= 1)
        {
            ballFace = GameObject.Find("2");
            ballFace.GetComponent<SpriteRenderer>().sprite = skinFace;

            if (hideFaceEyes)
            {
                eye1 = GameObject.Find("eys");
                eye2 = GameObject.Find("eys (1)");
                eye1.GetComponent<SpriteRenderer>().sprite = NoEyes;
                eye2.GetComponent<SpriteRenderer>().sprite = NoEyes;
            }
            else
            {
                eye1 = GameObject.Find("eys");
                eye2 = GameObject.Find("eys (1)");
                eye1.GetComponent<SpriteRenderer>().sprite = defaulteyes;
                eye2.GetComponent<SpriteRenderer>().sprite = defaulteyes;
            }

            previousScene = sceneIndex;
        }

        if (sceneIndex == 0)
        {
            button1 = GameObject.Find("skin1");
            button1.GetComponent<Button>().onClick.AddListener(delegate { changeSkin(defaultSkinFace); });
            button1.GetComponent<Button>().onClick.AddListener(delegate { hideEyes(false); });

            button2 = GameObject.Find("skin2");
            button2.GetComponent<Button>().onClick.AddListener(delegate { changeSkin(skinnum2); });
            button2.GetComponent<Button>().onClick.AddListener(delegate { hideEyes(true); });
        }

    }

    public void changeSkin(Sprite skin)
    {
        if(sceneIndex >= 1) { 
            ballFace.GetComponent<SpriteRenderer>().sprite = skin;
        }
        skinFace = skin ;

    }
    public void hideEyes(bool hide)
    {
        if (hide)
        {
            hideFaceEyes = true;
        }
        else
        {
            hideFaceEyes = false;
        }
    }

}
