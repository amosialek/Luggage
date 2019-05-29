using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3( 0, 0, -3 );

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
         transform.position = player.transform.position + offset;
    }
}
