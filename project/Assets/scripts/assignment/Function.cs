using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : MonoBehaviour
{
    //string firstName;
    //string lastName; 
    //int age; 

    int num1;
    int num2;
    int total;
    
    // Start is called before the first frame update

    void Start()
    {
       // firstName = "grace";

       // lastName = "jessen";

       // age = 19;

        //Customer(firstName, lastName, age);
        CalcAdd(11,231);
    
    }

    // Update is called once per frame
        int CalcAdd (int n1, int n2)
        {
            Debug.Log("Number 1 =" + n1+"Number 2=" + n2);
            total = n1 + n2;  
            Debug.Log(total);
            return total;
          
        }

        

    //void Customer(string firstName, string lastName, int age)
    //  debug.log(firstName + " " + lastName + " " + age);
    void Update ()
    {
            
    }
}