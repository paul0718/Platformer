using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 3;
    public float returnSpeed = 2.5f;
    public int damage = 1;
    public int enemyHP = 20;
    public float followRadius = 3.0f;
    public float attackRadius = 1.5f;

    GameObject player;
    Rigidbody2D player_rb;
    float attackCooldown = 3;
    float nextAttack;

    Vector3 startPos;

    Rigidbody2D _rigidbody;
    AudioSource _audioSource;
    public AudioClip hitSnd;
    Vector2 character;
    float dist;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        FindObjectOfType<HP>().setDefaultHealthPoint(10);
        startPos = transform.position;
        player = GameObject.FindWithTag("Player");
        player_rb = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        dist = Vector2.Distance(player.transform.position, transform.position);
        character = transform.localScale;
        if (checkShouldFollow(dist)) {
            if (checkShouldAttack(dist) && Time.time > nextAttack) {
                attack();
            }
            else {
                // Player is in front of the enemy.
                if (player.transform.position.x < transform.position.x) {
                    this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                    character.x = Math.Abs(character.x);
                }
                // Player is behind the enemy.
                if (player.transform.position.x > transform.position.x) {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                    character.x = -Math.Abs(character.x);
                }
            }
        }
        // transform.localScale = character;
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }

    }

    // Return true if the enemy should chase the player.
    bool checkShouldFollow(float dist)
    {
        if (dist < followRadius) {  return true; }
        return false;
    }

    // Return true if the enemy should attack the player.
    bool checkShouldAttack(float dist)
    {
        if (dist < attackRadius) { return true; }
        return false;
    }

    private void attack()
    {
        nextAttack = Time.time + attackCooldown;
        _audioSource.PlayOneShot(hitSnd);
        FindObjectOfType<HP>().loseHealth(damage);
        // Debug.Log("Player scale now: " + player.transform.localScale.x);
        // Debug.Log("Enemy scale now: " + this.transform.localScale.x);
        // Debug.Log("Force Added: " + 2000 * (-player.transform.localScale.x));
        player_rb.AddForce(new Vector2(20000 * (-player.transform.localScale.x), 500));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shuriken")){
            enemyHP -= 10;
            _audioSource.PlayOneShot(hitSnd);
            Destroy(other.gameObject);
        }
    }
}