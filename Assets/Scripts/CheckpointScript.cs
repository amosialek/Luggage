using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            col.gameObject.GetComponent<PlayerController2D>().SetCheckpointPosition(this.transform.position);
    }
}
