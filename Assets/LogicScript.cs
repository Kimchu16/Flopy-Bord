using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject bird;
    AudioSource bgMusic;
    AudioSource pointSFX;

    void Start()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        bgMusic = audio[0];
        pointSFX = audio[1];
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        pointSFX.Play();
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        //looks for the name of a scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        bgMusic.mute = true;
        Debug.Log("gameover");
        gameOverScreen.SetActive(true);
    }
}
