using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConMouse : MonoBehaviour
{
    Rigidbody2D body;
    public Transform thisPlayer;

    Vector3 mousePosition;
    Vector3 playerDirection;
   // float horizontal;
    //float vertical;
    private float runSpeed = 1f;
    CircleCollider2D circleColliderComponent;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circleColliderComponent = GameObject.FindWithTag("Player").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

          if (Input.GetKey(KeyCode.Mouse1))
          {
              mousePosition = Input.mousePosition;
              mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
              transform.position = Vector2.Lerp(transform.position, mousePosition, runSpeed * Time.fixedDeltaTime);
          }

       // horizontal = Input.GetAxis("Mouse X");
       // vertical = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 1f;
        }
        else
        {
            runSpeed = 2f;
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



   // private void FixedUpdate()
   // {
   //     body.velocity = new Vector2(horizontal * runSpeed * 10, vertical * runSpeed * 10);
    //}

}
