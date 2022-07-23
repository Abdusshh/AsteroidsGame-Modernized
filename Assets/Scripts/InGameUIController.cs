using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public GameObject[] hearts;

    private void Update()
    {
        PlayerController.wait += Time.deltaTime;
        
        if ((int)PlayerController.wait%3==0 && PlayerController.health<0)
        {
            PlayerController.wait += 1;
            LevelController.LoadNextLevel();
        }
    }
    
    public void UpdateHealth(int hp) //Updating health
    {
        for (int i = 0; i < 3; i++)
        {
            if (hp < i)
            {
                hearts[i].SetActive(false);
            }
            else
            {
                hearts[i].SetActive(true);
            }
        }    
    }
}
