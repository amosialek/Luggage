using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

	public float maxSpeed = 7;

    void Start()
    {
    }

    void FixedUpdate()
    {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
}
