using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 500;
    int jumps;
    float xSpeed = 0;
    Vector2 oldPos;
    Vector2 newPos;

    public LayerMask groundLayer;
    public Transform feet;
    public float distance = 10;
    public GameObject smokerPrefab;
    public Transform spawnPos;
    

    public bool facingLeft = false;
    public bool grounded = false;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        oldPos = newPos;
        if(grounded) //double jump
        {
            jumps = 1;
        }

        if(Input.GetButtonDown("Jump") && (jumps > 0 || grounded)) //jump
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            jumps--;
        }


        newPos = transform.position;
        CheckMoveDirection();
        if(Input.GetButtonDown("Fire3")) //shift click, this is the teleport command
        {
            GameObject newSmoke = Instantiate(smokerPrefab, spawnPos.position, Quaternion.identity);
            if(facingLeft){
                transform.position = new Vector2(transform.position.x-distance,transform.position.y); 
            }
            else{
                transform.position = new Vector2(transform.position.x+distance,transform.position.y);      
            }
            GameObject newSmoke2 = Instantiate(smokerPrefab, spawnPos.position, Quaternion.identity);
        }
    }

    void CheckMoveDirection() //checks to see if the player was moving left or right and sets a global variable to reflect it
    {
        if (oldPos.x > newPos.x){
            facingLeft = true;
        } else if (oldPos.x < newPos.x){
            facingLeft = false;
        }
    }

}
