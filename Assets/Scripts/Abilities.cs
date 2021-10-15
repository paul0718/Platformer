using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Abilities : MonoBehaviour
{
    public Image warpActive;
    public Image warpInactive;
    public int shurikenForce = 800;
    public LayerMask groundLayer;
    public Transform feet;
    public float distance = 10;
    public GameObject smokerPrefab;
    public Transform smokeSpawnPos;
    public GameObject shurikenPrefab;

    public AudioClip shurikenSnd;
    public AudioClip warpSnd;
    AudioSource _audioSource;

    float warpCooldown = 3;
    float nextWarp;
    float shurikenCooldown = 0.7f;
    float nextShuriken;
    Vector2 oldPos;
    Vector2 newPos;
    Rigidbody2D _rigidbody;
    public bool facingLeft = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckMoveDirection();
        oldPos = newPos;
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

        if(Time.time > nextWarp)
        {
            warpActive.gameObject.SetActive(true);
            warpInactive.gameObject.SetActive(false);
        } else {
            warpActive.gameObject.SetActive(false);
            warpInactive.gameObject.SetActive(true);
        }
        newPos = transform.position;
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
