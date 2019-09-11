using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private Tweener tweener;

    private List<GameObject> itemList;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

        itemList = new List<GameObject>();
        itemList.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
#if false

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 endPos = new Vector3(-2.0f, 0.5f, 0.0f);
            float duration = 1.5f;

            tweener.AddTween(item.transform, item.transform.position, endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            float duration = 1.5f;

            tweener.AddTween(item.transform, item.transform.position, endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            float duration = 0.5f;

            tweener.AddTween(item.transform, item.transform.position, endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            float duration = 0.5f;

            tweener.AddTween(item.transform, item.transform.position, endPos, duration);
        }
#endif
        if (Input.GetKeyDown(KeyCode.A))
        {

            Vector3 endPos = new Vector3(-2.0f, 0.5f, 0.0f);
            float duration = 1.5f;

            // Loop through the itemlist and attempt to add a new tween
            LoopAndAddTween(endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            float duration = 1.5f;

            // Loop through the itemlist and attempt to add a new tween
            LoopAndAddTween(endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            float duration = 0.5f;

            // Loop through the itemlist and attempt to add a new tween
            LoopAndAddTween(endPos, duration);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            float duration = 0.5f;

            // Loop through the itemlist and attempt to add a new tween
            LoopAndAddTween(endPos, duration);
        }

        // 100% Space
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // Clone item and put at (0,0.5,0), add the clone to the itemList
            itemList.Add(Instantiate(item, new Vector3(0, 0.5f, 0), Quaternion.identity));

        }
    }


    void LoopAndAddTween(Vector3 endPos, float duration)
    {
        foreach (GameObject item in itemList)
        {

            bool result = tweener.AddTween(item.transform, item.transform.position, endPos, duration);
            if (result)
            {
                break;
            }
            else  // False
            {
                // Do nothing
            }

        }
    }
}
