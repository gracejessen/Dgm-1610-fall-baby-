using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip DingSound;
    public AudioClip BorkSound;
    public float speed = 5.0f;
    public float xRange = 10;
    public float gravityModifier;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    private Animator PlayerAnim;
    private GameManager gameManager;

    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        PlayerAnim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * 30, ForceMode.Impulse);
                isOnGround = false;
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }

            if (!gameOver)
            {
                horizontalInput = Input.GetAxis("Horizontal");
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            }


                if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (other.gameObject.tag == "lethal")
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Destroy(other.gameObject);
            gameOver = true;
            gameManager.GameOver();
            Debug.Log("Game Over!");
            PlayerAnim.SetBool("Eat_b", true);
        }
        
            
        if (other.gameObject.CompareTag("yum"))
        {
            Destroy(other.gameObject);
            Debug.Log("Yum!");
            playerAudio.PlayOneShot(DingSound,1.0f);
            gameManager.UpdateScore(5);
        }

        if (other.gameObject.CompareTag("powerup"))
        {
           
            Destroy(other.gameObject);
            Debug.Log("Chicken nuggets!!");
            playerAudio.PlayOneShot(BorkSound,1.0f);
            gameManager.UpdateScore(2);
        }
    }
}


