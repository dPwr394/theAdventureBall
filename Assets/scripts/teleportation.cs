using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    private Transform player;
    public Transform reciever;
    public GameObject barrier;
    private Animation barrierAnim;
    public float dotProduct;
    public bool playerIsOverlapping = false;
    public float HowMuchPlayerNeedsToOverlap = 0f;
    private Vector3 teleporterToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        reciever = GameObject.Find("teleport_end").GetComponent<Transform>();
        barrier = GameObject.Find("barrier");
        barrierAnim = barrier.GetComponent<Animation>();
        barrier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping == true)
        {
            teleporterToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, teleporterToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f && HowMuchPlayerNeedsToOverlap == 0)
            {
                Teleport();
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
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
    private void Teleport()
    {
        // Teleport player!!!
        //float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
        //rotationDiff += 180;
        //player.Rotate(Vector3.up, rotationDiff);
        barrier.SetActive(true);
        Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * teleporterToPlayer;
        player.position = reciever.position + positionOffset;
        playerIsOverlapping = false;
        //barrierAnim
    }

}
