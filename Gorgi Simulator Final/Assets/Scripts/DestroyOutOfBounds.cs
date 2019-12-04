using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    
    private float topBound = 50;
    private float lowerBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
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
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
  
}
