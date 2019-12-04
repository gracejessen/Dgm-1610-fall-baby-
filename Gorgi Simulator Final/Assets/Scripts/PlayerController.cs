using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float speed = 5.0f;
    public float xRange = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 30, ForceMode.Impulse);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3( -xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Game Over!");
        }

        if (other.gameObject.name == "powerup")
        {
            Destroy(other.gameObject);
            Debug.Log("Powerup!");
        }
    }
}
