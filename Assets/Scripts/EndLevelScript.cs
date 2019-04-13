using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevelScript : MonoBehaviour
{
	private int waitingTimeInSec = 3;

    void OnTriggerEnter2D()
	{
		GameManager.GetInstance().WinLevel();
		StartCoroutine(WaitAndGoToMenu());
	}

	IEnumerator WaitAndGoToMenu()
    {
        yield return new WaitForSeconds(waitingTimeInSec);
		SceneManager.LoadScene(0);
    }
}
