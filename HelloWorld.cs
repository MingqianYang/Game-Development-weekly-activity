using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{

    private int number = 0;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("the number is : " + number++.ToString());
    }

    void Start()
    {
       
    }

}
