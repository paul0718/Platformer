using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float damage = 2;

    // Rigidbody2D _rigidbody;


    void Start()
    {
        // _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            FindObjectOfType<HP>().loseHealth(damage);
        }
      
    }
}

