using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public bool enableMouse = false;
    public bool enableKeyboard = true;

    Rigidbody2D body;
    public Transform thisPlayer;

    float horizontal;
    float vertical;
    Vector3 mousePosition;

    private float runSpeed = 10.0f;
    private float runSpeedMouse = 100f;
    CircleCollider2D circleColliderComponent;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circleColliderComponent = GameObject.FindWithTag("Player").GetComponent<CircleCollider2D>();

        settingsData data = saveSystemSettings.LoadSettings(); //when using cheat code givemeagun
        enableMouse = data.mouseOn;
        enableKeyboard = data.keyboardOn;

    }
    void Update()
    {
        if (enableKeyboard)
        {
            keyboardOn();
        }
        if (enableMouse)
        {
            MouseOn();
        }
    }

    void keyboardOn()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            runSpeed = 5f;
        else
            runSpeed = 10f;

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            circleColliderComponent = GameObject.FindWithTag("Player").GetComponent<CircleCollider2D>(); //in case cheatcode "gun" is active,new player object is being created
                                                                                                         //therefore we need to update the circleColliderComponent
                                                                                                         //to the new player object.
            circleColliderComponent.enabled = false;
            Debug.Log("Back quote key was pressed - Noclip enabled");
        }
        else if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            circleColliderComponent.enabled = true;
        }
    }

    void MouseOn() 
    {

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = Vector2.MoveTowards(transform.position, mousePosition, runSpeedMouse * Time.deltaTime);
        }

        // horizontal = Input.GetAxis("Mouse X");
        // vertical = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeedMouse = 4f;
        }
        else
        {
            runSpeedMouse = 8f;
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            circleColliderComponent = GameObject.FindWithTag("Player").GetComponent<CircleCollider2D>(); //in case cheatcode "gun" is active,new player object is being created
                                                                                                         //therefore we need to update the circleColliderComponent
                                                                                                         //to the new player object.
            circleColliderComponent.enabled = false;
            Debug.Log("Back quote key was pressed - Noclip enabled");
        }
        else if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            circleColliderComponent.enabled = true;
        }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
