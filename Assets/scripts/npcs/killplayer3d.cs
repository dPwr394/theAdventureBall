using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer3d : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = respawnPoint.transform.position;

    }
}
