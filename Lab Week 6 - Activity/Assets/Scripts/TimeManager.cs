using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Transform[] transformArray;
    const float moveWait = 2.0f;

    const float scaleWait = 4.0f;

    private int lastTime = 0;
    private float timer = 0.0f;
    private int counter = 0;
    private Vector3[] positions = { new Vector3(2,1,0), new Vector3(2, -1,0) , new Vector3(-2, -1,0) , new Vector3(-2, 1,0) };

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 2.0f;
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


            CancelInvoke("ScaleObjects");
        }

        // 60%        
        timer += Time.deltaTime;
        if (timer - lastTime >= 1f)
        {
            lastTime = (int)timer;
          
            Debug.Log(lastTime-1);

            MoveObjects();

        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }


        // 100%
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            float randomValue = UnityEngine.Random.Range(0.25f, 0.75f);
            StartCoroutine("RotateObjects", randomValue);

        }

    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;


        // The second parameter value?
         InvokeRepeating("ScaleObjects", 0.0f, scaleWait);

        
    }

    private void MoveObjects()
    {
        // move square clockwise
        if ((lastTime - 1) % moveWait == 0 && (lastTime - 1) >= moveWait)
        {

            for (int i = 0; i < transformArray.Length; i++)
            {
                int index = Array.IndexOf(positions, transformArray[i].position);
                if (index + 1 >= positions.Length)
                {
                    index = -1;
                }
                transformArray[i].position = positions[index + 1];
            }

        }
    }

    // 90%
    private void ScaleObjects()
    {
        for (int i = 0; i < transformArray.Length; i++)
        {
            if (transformArray[i].localScale.x > 1.5)
            {
                transformArray[i].localScale = transformArray[i].localScale / 1.2F;
            }
            else
            {
                transformArray[i].localScale = transformArray[i].localScale * 1.2F;

            }            

        }
    }

    IEnumerator RotateObjects(float randomDelay)
    {
        yield return new WaitForSeconds(randomDelay);
        for (int i = 0; i < transformArray.Length; i++)
        {
            transformArray[i].Rotate(Vector3.forward,  90, Space.World);
        }

        for (int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(randomDelay);
            for (int i = 0; i < transformArray.Length; i++)
            {
                transformArray[i].Rotate(Vector3.forward, 90, Space.World);
            }
        }
    }
}
