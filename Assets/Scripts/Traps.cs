using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int speed = 4;
    public float returnSpeed = 2.5f;
    public int damange;
    public int enemyHP;
    public float followRadius = 3.0f;
    public float attackRadius = 2.5f;

    public GameObject player;
    public HP hp;
    Vector3 startPos;

    Rigidbody2D _rigidbody;
    AudioSource _audioSource;
    public AudioClip hitSnd;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        // hp.setDefaultHealthPoint(20); 
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if (checkShouldAttack(dist)){
        //     trap_movement(x,y,z); //should contiue even if the player leaves attack range after triggered
        //     if (HitSuccess){
        //         player_ReceiveDamage(damage);
        //         trap_HPsetzero();
        //     }
        // }
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    bool checkShouldAttack(float dist)
    {
        if (dist < attackRadius) { return true; }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shuriken")){
            Destroy(other.gameObject);
            //trap_HPsetzero();
        }
        else if(other.CompareTag("Ground")){
            //trap_HPsetzero();
        }
        
    }
}

