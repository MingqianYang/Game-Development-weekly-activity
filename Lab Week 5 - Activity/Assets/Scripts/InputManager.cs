using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;// 

    float m_yRedPosition; 
    float m_yBluePosition; 

    // Start is called before the first frame update
    void Start()
    {
        // Declare transAray as an array of size 2
        transArray = new Transform[2];
     
        transArray[0] = GameObject.FindWithTag("Red").transform;
        transArray[1] = GameObject.FindWithTag("Blue").transform;

        m_yRedPosition = transArray[0].position.y;
        m_yBluePosition = transArray[1].position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject rebfab = GameObject.FindWithTag("Red");
        GameObject bluefab = GameObject.FindWithTag("Blue");

        // 70%
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (rebfab)
            {
                rebfab.transform.Rotate(0, 0, 45);
            }
            if (bluefab)
            {
                bluefab.transform.Rotate(0, 0, -45);
            }        
        }

        // 80%
        if (Input.GetButtonDown("Fire1")) 
        {

            Vector3 redPosition = transArray[0].position;
            Vector3 bluePosition = transArray[1].position;

            if (rebfab)
            {
                rebfab.transform.position = new Vector3(redPosition.x, m_yBluePosition, redPosition.z);
            }
            if (bluefab)
            {
                bluefab.transform.position = new Vector3(bluePosition.x, m_yRedPosition, bluePosition.z);
            }

            // Swap y posiiton
            float temp = m_yRedPosition;
            m_yRedPosition = m_yBluePosition;
            m_yBluePosition = temp;

        }

        // 90% change color 
        if (Input.GetButtonUp("Fire1"))
        {

            if (rebfab)
            {           
                if (rebfab.GetComponent<PrintAndHide>() != null)
                {
                    if (rebfab.GetComponent<PrintAndHide>().rend != null)
                    {
                        int randValue = Random.Range(51, 255);
                        rebfab.GetComponent<PrintAndHide>().rend.material.SetColor("_Color", new Vector4(randValue / 255f, 0.0f, 0.0f));

                        // Print out color
                        Color color = rebfab.GetComponent<PrintAndHide>().rend.material.color;
                        Debug.Log($"Red: {color}");
                    }

                }

            }

            if (bluefab)
            {
                if (bluefab.GetComponent<PrintAndHide>() != null)
                {
                    if (bluefab.GetComponent<PrintAndHide>().rend !=null)
                    {
                        int randValue = Random.Range(51, 255);
                        bluefab.GetComponent<PrintAndHide>().rend.material.SetColor("_Color", new Vector4(0.0f, 0.0f, randValue / 255f));

                        // Print out color
                        Color color = bluefab.GetComponent<PrintAndHide>().rend.material.color;
                        Debug.Log($"Blue: {color}");
                    }

                }
            }

        }

        // 100%  
        if (Input.GetKeyDown(KeyCode.E))
        {
       
            if (rebfab != null)
            {
                // redObj
                if (rebfab.GetComponent<PrintAndHide>() != null)
                {
                    Destroy(rebfab.GetComponent<PrintAndHide>());
                }
                else
                {
                    rebfab.AddComponent<PrintAndHide>();
                    rebfab.SetActive(true);
                }
            }
           
            // blueObj
            if (bluefab.GetComponent<PrintAndHide>() != null)
            {
                Destroy(bluefab.GetComponent<PrintAndHide>());
            }
            else
            {
                bluefab.AddComponent<PrintAndHide>();
                bluefab.SetActive(true);
            }
            
        }
    }


}
