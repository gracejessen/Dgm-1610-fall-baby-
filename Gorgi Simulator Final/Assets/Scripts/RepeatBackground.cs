using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playerControllerScript = GameObject.Find("Corgi").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -19 && playerControllerScript.gameOver ==false)
        {
            transform.position = startPos;
        }
    }
}

