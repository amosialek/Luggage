using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;
	public GameObject winText;

	void Awake()
	{
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
		winText.SetActive(true);
	}
}
