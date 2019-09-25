using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    const string saveSpeedKey = "Save Speed";

    // Start is called before the first frame update
    void Start()
    {
        LoadSpeedState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SaveSpeed()
    {
        int saveValue = (int)SpeedManager.CurrentSpeedState;
        int loadValue = PlayerPrefs.GetInt(saveSpeedKey);
        if (!saveValue.Equals(loadValue))
        {
            PlayerPrefs.SetInt(saveSpeedKey, saveValue);
            PlayerPrefs.Save();

        }
    }

    public void  LoadSpeedState()
    {
        SpeedManager.CurrentSpeedState =(SpeedManager.GameSpeed) PlayerPrefs.GetInt(saveSpeedKey);
    }
}
