using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject Panel;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showCredits() { Panel.SetActive(true); anim.SetBool("show", true); anim.SetBool("hide", false); }

    public void HideCredits() {
        anim.SetBool("hide", true); 
        anim.SetBool("show", false);
        Invoke("disableit", 1);
    }
    private void disableit()
    {
        Panel.SetActive(false);

    }
}
