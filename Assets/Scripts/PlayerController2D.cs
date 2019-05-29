using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    public GameManager gameManager;
	public float maxSpeed = 7;
    private Vector3 checkpointPosition;
    public Sprite openSprite;
    public Sprite closedSprite;
    private int currentSprite=0;
    void Awake()
    {
        this.checkpointPosition = this.transform.position;
    }

    void FixedUpdate()
    {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0.0f, 0.0f));
        if (Input.GetKey("space"))
        {
            gameManager.Score(-1);
            if (currentSprite == 0)
            {
                this.GetComponent<SpriteRenderer>().sprite= openSprite;
                currentSprite = 1;
            }
        }
        else
        {
            if (currentSprite == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = closedSprite;
                currentSprite = 0;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        float collsion = Vector2.Dot(transform.position - col.transform.position, Physics2D.gravity);

        if (collsion > 4 && Input.GetKey("space"))
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": gameManager.EatEnemy(); col.gameObject.SetActive(false); break;
                case "Item": gameManager.EatItem(); col.gameObject.SetActive(false); break;
                case "EndLevel": gameManager.WinLevel(); StartCoroutine(WaitAndGoToMenu()); break;
            }
        } else
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": this.transform.position = checkpointPosition; gameManager.Die(); break;
                case "EndLevel": gameManager.WinLevel(); StartCoroutine(WaitAndGoToMenu()); break;
            }
        }
    }
	
	void OnCollisionStay2D(Collision2D col)
    {
        float collsion = Vector2.Dot(transform.position - col.transform.position, Physics2D.gravity);

        if (collsion > 4 && Input.GetKey("space"))
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": gameManager.EatEnemy(); col.gameObject.SetActive(false); break;
                case "Item": gameManager.EatItem(); col.gameObject.SetActive(false); break;
                case "EndLevel": gameManager.WinLevel(); StartCoroutine(WaitAndGoToMenu()); break;
            }
        } else
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": this.transform.position = checkpointPosition; gameManager.Die(); break;
                case "EndLevel": gameManager.WinLevel(); StartCoroutine(WaitAndGoToMenu()); break;
            }
        }
    }

    public void SetCheckpointPosition(Vector3 position)
    {
        this.checkpointPosition = position;
    }
	
	IEnumerator WaitAndGoToMenu()
    {
        yield return new WaitForSeconds(3);
		SceneManager.LoadScene(0);
    }
}
