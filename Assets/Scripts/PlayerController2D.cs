using System.Collections;
using System.Collections.Generic;
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
        float collsion = Vector2.Dot(transform.position - col.transform.position, Physics2D.gravity);

        if (collsion > 4)
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": col.gameObject.SetActive(false); break;
                case "Item": gameManager.Score(); col.gameObject.SetActive(false); break;
            }
        } else
        {
            switch (col.gameObject.tag)
            {
                case "Enemy": gameManager.Die(); break;
            }
        }
    }
}
