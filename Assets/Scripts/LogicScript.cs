using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour, IData
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject bird;
    AudioSource bgMusic;
    AudioSource pointSFX;
    public TextMeshProUGUI highscoreUI;
    private int highscore = 0;

    public void LoadData(GameData data)
    {
        this.highscore = data.highscore;
    }

    public void SaveData(ref GameData data)
    {
        data.highscore = this.highscore;
    }

    void Start()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        bgMusic = audio[0];
        pointSFX = audio[1];
    }

    public void UpdateHighscore()
    {
        highscore = playerScore;
        highscoreUI.text = highscore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        pointSFX.Play();
        scoreText.text = playerScore.ToString();

        if (playerScore > highscore)
        {
            UpdateHighscore();
        }
    }

    public void GameOver()
    {
        highscoreUI.text = highscore.ToString();
        bgMusic.mute = true;
        Debug.Log("gameover");
        gameOverScreen.SetActive(true);
    }
}
