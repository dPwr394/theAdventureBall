using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer playerRenderer;
    public Transform reciever;
 //   public GameObject barrier;
    private Animator fade;
    public float dotProduct;
    public bool playerIsOverlapping = false;
    public float HowMuchPlayerNeedsToOverlap = 0f;
    private Vector3 teleporterToPlayer;
//    private bool timezero = false;
    public float seconds = 5f;
    private float sec;
    // Start is called before the first frame update
    void Start()
    {
        sec = seconds;
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        reciever = GameObject.Find("teleport_end").GetComponent<Transform>();
        fade= GameObject.Find("Player").GetComponent<Animator>();
        fade.SetBool("outOfTeleporter", true);
        fade.ResetTrigger("fadein");
        fade.ResetTrigger("fadeout");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping == true)
        {
            seconds -= Time.fixedDeltaTime;
            teleporterToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, teleporterToPlayer);
            
            //if this is true: The player has moved across the portal
            if (dotProduct < 0f && HowMuchPlayerNeedsToOverlap == 0)
            {
                if (seconds <= 0f) {
                    fade.SetTrigger("fadeout");
                    Teleport();
                    seconds = sec;
                }
            }
            if (dotProduct < 0f && HowMuchPlayerNeedsToOverlap != 0)
            {
                HowMuchPlayerNeedsToOverlap -= 0.5f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            fade.SetBool("outOfTeleporter", false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fade.SetTrigger("fadeout");
                
            if (seconds <= 0f)
            {
                Teleport();
                seconds = sec;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            fade.SetBool("outOfTeleporter", true);
            //fade.ResetTrigger("fadein");
            //fade.ResetTrigger("fadeout");
            seconds = sec;
        }
    }
    private void Teleport()
    {
        // Teleport player!!!
        //float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
        //rotationDiff += 180;
        //player.Rotate(Vector3.up, rotationDiff);

        Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * teleporterToPlayer;
        player.position = reciever.position + positionOffset;
        playerIsOverlapping = false;
        fade.ResetTrigger("fadeout");
        //barrier.SetActive(true);
        //   barrierAnim.SetBool("close", true);

    }

  //  private void timer()
  //  {
   //     seconds -= Time.fixedDeltaTime;
   //     if (seconds <= 0){
   //         timezero = true;
   //     }
   //     else { timezero = false; }
   // }

}
