using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image innerHealthBar;
    private Transform playerTransform;
    private float healValue;

    private Transform healthBillboard;
    private float rotateSpeed = 10.0f;

    // Preserve the game object that this component is attached to
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform!=null)
        {
            //healthBillboard.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
           
            float number = Mathf.Clamp(Mathf.Abs(playerTransform.position.x), 0.0f, 5.0f);
            healValue = 1 - 1 / 5.0f  * number;
            innerHealthBar.fillAmount = healValue;
            if (healValue < 0.5f)
            {
                innerHealthBar.color = Color.red;
            }
            if (healValue>0.5f)
            {
                innerHealthBar.color = Color.green;
            }
           
        }

        if (Input.GetKey(KeyCode.J))
        {
            Camera.main.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.L))
        {

            Camera.main.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        }

    }
    void LateUpdate()
    {
        healthBillboard.forward = -Camera.main.transform.forward;
    }
    public void LoadFirstLevel()
    {
        
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex >=0)
        {
            Button quitButton =  GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
            quitButton.onClick.AddListener(QuitMethod);

            innerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            healthBillboard = GameObject.FindGameObjectWithTag("healthBillboard").GetComponent<Transform>();
            
        }
    }

    void QuitMethod()
    {
        QuitGame();
    }

 
}
