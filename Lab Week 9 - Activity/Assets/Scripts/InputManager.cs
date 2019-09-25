using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpeedManager.CurrentSpeedState = SpeedManager.CurrentSpeedState == SpeedManager.GameSpeed.Slow ? SpeedManager.GameSpeed.Fast : SpeedManager.GameSpeed.Slow;
            GetComponent<SaveGameManager>().SaveSpeed();

        }

        if (GameManager.currentGameState == GameManager.GameState.Start && Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.currentGameState = GameManager.GameState.WalkingLevel;
            SceneManager.LoadScene(0);
            
        }
    }
}
