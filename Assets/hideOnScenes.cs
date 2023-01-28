using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class hideOnScenes : MonoBehaviour
{
    private static hideOnScenes instance;
    public int sceneIndex;
    public int[] whereVisible; //what scene
    private GameObject thisObj;
    private Transform oldPos;
    private GameObject canvs;
    // Start is called before the first frame update
    void Start()
    {
        thisObj.GetComponent<Transform>();
        oldPos.position = thisObj.transform.position;

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        for (int i = 0; i < whereVisible.Length; i++)
        {
            if (sceneIndex == whereVisible[i])
            {
                //thisObj.transform.position = oldPos.position;
                canvs = GameObject.Find("Canvas");
                canvs.GetComponent<Transform>();
                thisObj.transform.SetParent(canvs.transform);
            }
            else
            {
                //Vector3 v3 = transform.position;
                //v3.x += 200.0f;
               // transform.position = v3;
            }
        }
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

        oldPos.position = thisObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
