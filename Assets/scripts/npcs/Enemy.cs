﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public GameObject deathEffect;
    public GameObject explosion;

    void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
