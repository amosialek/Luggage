using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollScript : MonoBehaviour
{
	public Rigidbody2D rb;
	public float maxSpeed = 2;
	public SpriteRenderer sr;

	private float currentSpeed;

    void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		currentSpeed = maxSpeed;
    }

    void FixedUpdate()
	{
		rb.velocity = new Vector2(currentSpeed, 0.0f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "PatrolFlag") {
			if (sr.flipX == false) {
				sr.flipX = true;
				currentSpeed = -maxSpeed;
				return;
			} else {
				sr.flipX = false;
			}
			currentSpeed = maxSpeed;
		}
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
             case "Item": col.gameObject.SetActive(false); break;
        }
    }
}

