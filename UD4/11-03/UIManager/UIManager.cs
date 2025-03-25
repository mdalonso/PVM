using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text finalScoreText;

    [SerializeField] GameObject gameOverScreen;

    [SerializeField] GameStats _gameStats;

    public void UpdateUIScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    public void UpdateUIHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }
    public void UpdateUITime(int newTime)
    {
        timeText.text = newTime.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScoreText.text=_gameStats.Score.ToString();
    }
}
