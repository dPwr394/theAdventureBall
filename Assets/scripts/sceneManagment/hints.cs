using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class hints : MonoBehaviour
{
    public string sceneName;
    private string previousScene;
    public int sceneIndex;
    private static hints instance;
    public GameObject hintText;
    public bool enableIt = true;
    public GameObject toggleButton;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousScene = sceneName;

    }

    private void Awake()
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

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneName == "sp_basics" || sceneName == "sp_gun")
        {
            hintText = GameObject.Find("hints");
            if (enableIt)
            {
                hintText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
            else
            {
                hintText.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            }
        }

        if (sceneIndex == 0)
        {
            toggleButton = GameObject.Find("ToggleHints");
            toggleButton.GetComponent<Toggle>().onValueChanged.AddListener(delegate { KillText(enableIt); });
        }

    }

    public void KillText(bool hideValue)
    {
        enableIt = hideValue;
        //toggleButton.GetComponent<Toggle>().isOn = hideValue;
    }
}

