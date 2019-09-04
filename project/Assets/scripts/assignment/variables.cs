using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variables : MonoBehaviour
{
    string firstname = "grace";
    int age = 19;
    float height = 5.8f; 
    bool relationship = false; 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("firstname "+ firstname);
        Debug.Log("age" + age);
        Debug.Log("height" + height);
        Debug.Log(" relationship" + relationship);
    }


    // Update is called once per frame 
        

}
