using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTimeScale : MonoBehaviour
{
    private float fixedDeltaTime;
    // Start is called before the first frame update
    private void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
