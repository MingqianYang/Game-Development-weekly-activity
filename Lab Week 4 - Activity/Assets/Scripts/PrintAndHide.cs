using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class PrintAndHide : MonoBehaviour
{
    private int i;
    private int randomNumber;
    public Renderer rend;
   
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Random random = new Random();
        randomNumber =  random.Next(200, 250);
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{gameObject.name}:  {i++} ");

        if (GameObject.FindWithTag("Red") && i ==100)
        {
            gameObject.SetActive(false);
        }

        if (GameObject.FindWithTag("Blue") && i == randomNumber)
        {
            rend.enabled = false;
        }
    }
}
