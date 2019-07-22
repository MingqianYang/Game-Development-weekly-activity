using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{

    private int number = 0;
    float _t = 0f;

    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;

        if (_t >= 1f)
        {
            _t = 0f;
            Debug.Log("the number is : " + number++.ToString());
        }
    }

    void Start()
    {
        //StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        while (true)
        {
            Debug.Log("the number is : " + number++.ToString());

            yield return new WaitForSeconds(1f);
        }

    }

}
