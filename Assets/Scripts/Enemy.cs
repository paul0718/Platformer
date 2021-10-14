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
    public float attackRadius = 2.7f;

    public GameObject player;
    Vector3 startPos;

    Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        // Debug.Log("Dist: " + dist);
        if (checkShouldFollow(dist)) {
            if (checkShouldAttack(dist)) {
                // Player loses HP by damnage.
                Debug.Log("Play loses HP!");
            }
            else {
                // Player is in front of the enemy.
                if (player.transform.position.x < transform.position.x) {
                    this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                }
                // Player is behind the enemy.
                if (player.transform.position.x > transform.position.x) {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                }
            }

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
}
