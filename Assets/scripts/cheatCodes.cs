using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatCodes : MonoBehaviour
{
    //based on https://answers.unity.com/questions/553597/how-to-implement-cheat-codes.html
    public bool sixtyNine = false;
    public bool weaponCode = false;
    public GameObject GunPrefab;
    public bool noliferCode = false;
    public GameObject noliferPrefab;
    public int index = 0;
    public string[] Code;
    private GameObject PlayerNoGun;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(Code[index]) )
            {
                // Add 1 to index to check the next key in the code
                index=index+1;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == Code.Length)
        {
            // Cheat code successfully inputted!
            if (sixtyNine)
            {
                sixtyNineExe();
            }
            if (weaponCode)
            {
                gunCodeExe();
            }
            if (noliferCode)
            {
                noliferExe();
            }

            index = 0;
        }
    }

    void sixtyNineExe()
    {
        Debug.Log("quit");
        Application.Quit();
        index = 0;
    }
    void gunCodeExe()
    {
        Debug.Log("gun");
            PlayerNoGun = GameObject.Find("Player");
            Instantiate(GunPrefab, PlayerNoGun.transform.position, PlayerNoGun.transform.rotation);
            Destroy(PlayerNoGun);
            index = 0;
    }

    void noliferExe()
    {
        Debug.Log("bruh hell nahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        Instantiate(noliferPrefab);
        index = 0;
    }

}
