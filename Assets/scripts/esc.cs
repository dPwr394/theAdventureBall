﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }
}
