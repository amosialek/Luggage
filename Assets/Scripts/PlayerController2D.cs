using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public GameManager gameManager;
	public float maxSpeed = 7;

    void Start()
    {
    }

    void FixedUpdate()
    {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy": gameManager.Die(); break;
            case "Item": gameManager.Score(); col.gameObject.SetActive(false); break;
			case "EndLevel": gameManager.WinLevel(); StartCoroutine(WaitAndGoToMenu()); break;
        }
    }
	
	IEnumerator WaitAndGoToMenu()
    {
        yield return new WaitForSeconds(3);
		SceneManager.LoadScene(0);
    }
}
