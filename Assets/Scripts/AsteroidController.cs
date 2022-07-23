using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    [SerializeField] private float asteroidSpeed;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //Asteroids going to random places according to the player
        rigidBody.AddRelativeForce((PlayerController.directionGetter.normalized+new Vector3(Random.Range(0,1),Random.Range(0,1)))*asteroidSpeed);
    }
    
}
