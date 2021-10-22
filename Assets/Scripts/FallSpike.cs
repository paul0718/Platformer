using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpike : MonoBehaviour
{

    Rigidbody2D _rigidbody;
    GameObject player;
    public float attackRadius = 4f;
    float dist_x;
    bool below = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0.0f;
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate(){
        dist_x = Vector2.Distance(player.transform.position, transform.position);
        below = player.transform.position.y < transform.position.y;
        // Debug.Log("distance between is now:" + dist);
        if (checkShouldAttack(dist_x, below)) {
            _rigidbody.gravityScale = 3.0f;
        }

    }


    bool checkShouldAttack(float dist, bool below)
    {
        if ((dist < attackRadius) && below) { return true; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            FindObjectOfType<HP>().loseHealth(10.0f);
        }
        else if (other.CompareTag("Ground")){
            Destroy(gameObject);
        }
      
    }
}
