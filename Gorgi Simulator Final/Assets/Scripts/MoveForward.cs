using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Corgi").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (playerControllerScript.gameOver == false)

            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
        }
    }
}