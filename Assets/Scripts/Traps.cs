using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float damage = 2;
    AudioSource _audioSource;
    public AudioClip hitSnd;
    // Rigidbody2D _rigidbody;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        // _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            _audioSource.PlayOneShot(hitSnd);
            FindObjectOfType<HP>().loseHealth(damage);
        }
      
    }
}

