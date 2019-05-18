using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy { }
public class AxeMan : MonoBehaviour, IEnemy
{
    public GameObject player;
    private Rigidbody2D axeManRigidBody;
    private float visibilityRange=10e3f;
    public float Force = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        axeManRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDistance = gameObject.transform.position.x - player.transform.position.x;
        float yDistance = gameObject.transform.position.y - player.transform.position.y;
        if (xDistance * xDistance + yDistance * yDistance < visibilityRange * visibilityRange)
        {
            var gravity = Physics2D.gravity;
            var force = (Math.Abs(gravity.x) > Math.Abs(gravity.y))
                ? new Vector2(0f, -Math.Sign(yDistance)*Force)
                : new Vector2(-Math.Sign(xDistance)*Force, 0f);
            axeManRigidBody.AddForce(force);
        }
    }
}
