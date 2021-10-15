using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 4;
    public float returnSpeed = 2.5f;
    public int damange;
    public int enemyHP;
    public float followRadius = 3.0f;
    public float attackRadius = 1.5f;

    public GameObject player;
    public HP hp;
    float attackCooldown = 3;
    float nextAttack;

    Vector3 startPos;

    Rigidbody2D _rigidbody;
    AudioSource _audioSource;
    public AudioClip hitSnd;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        hp.setDefaultHealthPoint(10);
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        Vector3 character = transform.localScale;
        if (checkShouldFollow(dist)) {
            if (checkShouldAttack(dist) && Time.time > nextAttack) {
                nextAttack = Time.time + attackCooldown;
                _audioSource.PlayOneShot(hitSnd);
                hp.loseHealth(damange);
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000 * transform.localScale.x, 200));
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
        transform.localScale = character;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shuriken")){
            enemyHP -= 10;
            _audioSource.PlayOneShot(hitSnd);
            Destroy(other.gameObject);
        }
    }
}