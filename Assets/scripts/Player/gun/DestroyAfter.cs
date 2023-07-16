using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float lifeTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime-= Time.fixedDeltaTime;
        if (lifeTime <= 0.0f) {
            Destroy(this.gameObject);
        }
    }
}
