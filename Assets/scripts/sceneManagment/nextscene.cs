﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene(index);

            //SceneManager.LoadScene("LeveName");

            //SceneManager.LoadScene(SceneManager.GetAxisScene().buildIndex;
        }

    }
}
