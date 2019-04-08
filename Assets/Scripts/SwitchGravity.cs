using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private float gravityFactor = 9.8f;

    void Start()
    {
        Physics2D.gravity = new Vector2(0, -gravityFactor);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Physics2D.gravity = new Vector2(0, -gravityFactor);
            transform.eulerAngles = Vector3.zero;
        } else if (Input.GetKeyDown(KeyCode.I))
        {
            Physics2D.gravity = new Vector2(0, gravityFactor);
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Physics2D.gravity = new Vector2(-gravityFactor, 0);
            transform.eulerAngles = new Vector3(0, 0, 270f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Physics2D.gravity = new Vector2(gravityFactor, 0);
            transform.eulerAngles = new Vector3(0, 0, 90f);
        }
    }
}
