using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    private Rigidbody2D portalRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        portalRigidBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Item": col.gameObject.SetActive(false); break;
            case "Enemy": col.gameObject.SetActive(false); break;
        }
    }
}
