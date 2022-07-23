using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public GameObject Effect;
    
    [SerializeField] private float speed;
    
    private void Start()
    {
        //Bullet movement
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddRelativeForce(new Vector3 (0,speed));
        
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            //Destroying asteroids
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
            Destroy(spriteRenderer);
            Instantiate(Effect, other.transform.position, Quaternion.identity);
            Destroy(other);
            Destroy(gameObject);
            ScoreScript.score += 1;
        }
    }
}
