using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject MenuPanel;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(false);
        IsPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (IsPaused) {Resume();}
            else { Paused(); }
        }
    }

    public void Resume()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Paused()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
