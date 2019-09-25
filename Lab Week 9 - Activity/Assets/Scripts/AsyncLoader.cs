using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadLevelAsync();
    }
    public void LoadLevelAsync()
    {
        if (pos.x>2.5f)
        {
            if (!SceneManager.GetSceneByBuildIndex(4).isLoaded)
            {
                SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
            }
            if (SceneManager.GetSceneByBuildIndex(3).isLoaded )
            {
                SceneManager.UnloadSceneAsync(3);
            }
                   
        } 
        if (pos.x<-2.5f)
        {
            if (!SceneManager.GetSceneByBuildIndex(3).isLoaded)
            {
                SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
            }
            if (SceneManager.GetSceneByBuildIndex(4).isLoaded)
            {
                SceneManager.UnloadSceneAsync(4);
            }     
           
        }
         if (pos.z > 2.5f)
        {
            if (!SceneManager.GetSceneByBuildIndex(5).isLoaded)
            {
                SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
            }
            if (SceneManager.GetSceneByBuildIndex(2).isLoaded)
            {
                SceneManager.UnloadSceneAsync(2);
            }

        }
         if (pos.z < -2.5f)
        {
            if (!SceneManager.GetSceneByBuildIndex(2).isLoaded)
            {
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }
            if (SceneManager.GetSceneByBuildIndex(5).isLoaded)
            {
                SceneManager.UnloadSceneAsync(5);
            }

        }
     
    }
}
