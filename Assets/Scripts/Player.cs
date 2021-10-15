using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 500;
    public int shurikenForce = 800;
    int jumps;
    float xSpeed = 0;
    Vector2 oldPos;
    Vector2 newPos;

    public LayerMask groundLayer;
    public Transform feet;
    public float distance = 10;
    public GameObject smokerPrefab;
    public Transform smokeSpawnPos;
    public GameObject shurikenPrefab;

    public AudioClip jumpSnd;
    public AudioClip shurikenSnd;
    public AudioClip warpSnd;
    AudioSource _audioSource;

    float warpCooldown = 3;
    float nextWarp;
    float shurikenCooldown = 1;
    float nextShuriken;
    

    public bool facingLeft = false;
    public bool grounded = false;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        if((facingLeft == false && transform.localScale.x < 0) || (facingLeft == true && transform.localScale.x > 0) )
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveDirection();
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        oldPos = newPos;
        if(grounded)
        {
            jumps = 1;
        }

        if(Input.GetButtonDown("Jump") && (jumps > 0 || grounded))
        {
            if (_audioSource == null) Debug.LogError("playerAudio is null on " + gameObject.name);
            if (jumpSnd == null) Debug.LogError("crashSound is null on " + gameObject.name);
            _audioSource.PlayOneShot(jumpSnd);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            jumps--;
        }
        newPos = transform.position;
        
        if(Input.GetButtonDown("Fire1") && Time.time > nextShuriken)
        {
            nextShuriken = Time.time + shurikenCooldown;
            _audioSource.PlayOneShot(shurikenSnd);
            GameObject newShuriken = Instantiate(shurikenPrefab, transform.position, Quaternion.identity);
            newShuriken.GetComponent<Rigidbody2D>().AddForce(new Vector2(shurikenForce * transform.localScale.x, 0));

        }

        if(Input.GetButtonDown("Fire3") && Time.time > nextWarp)
        {
            nextWarp = Time.time + warpCooldown;
            _audioSource.PlayOneShot(warpSnd);
            GameObject newSmoke = Instantiate(smokerPrefab, smokeSpawnPos.position, Quaternion.identity);
            if(facingLeft){
                transform.position = new Vector2(transform.position.x-distance,transform.position.y); 
            }
            else{
                transform.position = new Vector2(transform.position.x+distance,transform.position.y);      
            }
            GameObject newSmoke2 = Instantiate(smokerPrefab, smokeSpawnPos.position, Quaternion.identity);
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
}
