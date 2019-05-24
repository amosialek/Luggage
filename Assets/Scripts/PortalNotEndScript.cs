using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNotEndScript : MonoBehaviour
{
    [SerializeField] public Transform teleportTo;
    private Rigidbody2D portalRigidBody;
    [SerializeField] string tag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        portalRigidBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (tag == string.Empty || col.CompareTag(tag))
        {
            col.transform.position = teleportTo.position;
        }
    }
}
