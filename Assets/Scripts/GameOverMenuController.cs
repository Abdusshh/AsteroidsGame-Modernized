using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "FINAL SCORE " + ScoreScript.score;
    }

    public void OnRestartButton()
    {
        LevelController.LoadLevel(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
