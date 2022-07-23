using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private new Camera camera;
    public GameObject Asteroid;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public GameObject Effect;
    public GameObject Effect2;
    [SerializeField] private float forwardForce;
    [SerializeField] private float rotationForce;
    [SerializeField] private float maxSpeed;
    public static int health;
    public InGameUIController ui;
    public static float wait;
    private Vector3 position;
    public static Vector3 directionGetter;
    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody from the player GameObject
        camera = Camera.main;
        health = 2;
    }
    
    void Update()
    {
        Debug.Log(wait);

        //Losing hearts
        ui.UpdateHealth(health);
        
        //Dying
        if (health<0)
        {
            Instantiate(Effect2,transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("GameOver");
            
        }
        
        //Player not leaving the camera 
        if (camera.WorldToScreenPoint(transform.position).x >= camera.scaledPixelWidth)
        {
            transform.position = new Vector3(-transform.position.x+0.3f,transform.position.y,0);
        }
        else if(camera.WorldToScreenPoint(transform.position).x <= 0)
        {
            transform.position = new Vector3(-transform.position.x-0.3f,transform.position.y,0);
        }
        else if (camera.WorldToScreenPoint(transform.position).y <= 0)
        {
            transform.position = new Vector3(transform.position.x,-transform.position.y-0.3f,0);
        }
        else if (camera.WorldToScreenPoint(transform.position).y >= camera.scaledPixelHeight)
        {
            transform.position = new Vector3(transform.position.x,-transform.position.y+0.3f,0);
        }
        
        //Moving
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxSpeed); //velocity limit
        rigidBody.AddRelativeForce(new Vector3 (0,forwardForce * verticalInput * Time.deltaTime));
        
        //Rotating
        transform.Rotate(0, 0, (-horizontalInput * rotationForce * Time.deltaTime));

        //Creating asteroids on random locations
        if ((int)wait%2==0 && (int)wait!=0)
        {
            wait += 1;
            Vector3 asteroidPosition = Random.insideUnitCircle.normalized*10;
            float val = Random.value;
            if (val>0.66f)
            {
                Instantiate(Asteroid, asteroidPosition, Quaternion.identity);
            }
            else if(val<0.33f)
            {
                Instantiate(Asteroid2, asteroidPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(Asteroid3, asteroidPosition, Quaternion.identity);
            }
            Vector3 direction = transform.position - asteroidPosition;
            directionGetter = direction;
        }
    }
    
    //Collisions with meteors
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health -= 1;
            Destroy(collision.gameObject);
            Instantiate(Effect,collision.gameObject.transform.position, Quaternion.identity);
            ScoreScript.score += 1;
        }
    }

}
