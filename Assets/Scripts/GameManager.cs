using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;
	public GameObject winText;
	public GameObject gameOverText;
    private LifeCounter lifeCounter;
    private ScoreCounter scoreCounter;
    private AchievementsManager achievementsManager;

    void Awake()
	{
        lifeCounter = this.GetComponent<LifeCounter>();
        scoreCounter = this.GetComponent<ScoreCounter>();
        achievementsManager = this.GetComponent<AchievementsManager>();
        lifeCounter.Refresh();
        scoreCounter.Refresh();
		if (instance == null)
		{
			instance = this;
		} else
		{
			Destroy(gameObject);
		}
	}

	public static GameManager GetInstance()
	{
		return instance;
	}

	public void WinLevel()
	{
        PlayerPrefs.SetInt("PassedLevels",Math.Max(PlayerPrefs.GetInt("PassedLevels"), SceneManager.GetActiveScene().buildIndex));
        PlayerPrefs.Save();
        winText.SetActive(true);
	}

    public void GameOver()
    {
        gameOverText.SetActive(true);
        SceneManager.LoadScene(0);
    }

    internal void Score(int score)
    {
        scoreCounter.Counter+=score;
    }

    public void Die()
    {
        lifeCounter.Counter = lifeCounter.Counter - 1;
        achievementsManager.Die();
        if (lifeCounter.Counter > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            GameOver();
    }
}
