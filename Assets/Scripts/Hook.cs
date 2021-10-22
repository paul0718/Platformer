using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool facingLeft = false;
    Vector2 oldPos;
    Vector2 newPos;
    public float speedRotate = 3;

    // Update is called once per frame
    void Update()
    {
        CheckMoveDirection();
        transform.Rotate(Vector3.forward * speedRotate);
    }

    void FixedUpdate()
    {
        if((facingLeft == false && transform.localScale.x > 0) || (facingLeft == true && transform.localScale.x < 0) )
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    void CheckMoveDirection()
    {
        if (oldPos.x > newPos.x){
            facingLeft = true;
        } else if (oldPos.x < newPos.x){
            facingLeft = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            // _audioSource.PlayOneShot(hitSnd);
            FindObjectOfType<HP>().loseHealth(3.0f);
            Destroy(gameObject);
        }
    }
    
}

