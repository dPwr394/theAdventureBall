using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject Target;
    private Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Target = GameObject.FindWithTag("Player");
            transform.position = Target.transform.position + Offset;
        }
    }
}