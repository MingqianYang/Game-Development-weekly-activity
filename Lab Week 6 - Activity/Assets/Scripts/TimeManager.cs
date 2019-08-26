using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime = 0;
    private float timer = 0.0f;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {

        // 40$
/*        if (Time.time - lastTime >= 1f)
        {
            lastTime =  (int)Time.time;

            Debug.Log($"{lastTime-1}");           

        }*/


        // 50%
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale != 0.0f)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            
            Debug.Log("Spacebar pressed");
        }

        // 60%        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer -= 1.0f;
            Debug.Log(counter++);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }


    }

    private void ResetTime()
    {
        counter = 0;
    }

}
