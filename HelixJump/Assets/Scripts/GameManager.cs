using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject LevelPanel;
    void Start()
    {
        Time.timeScale = 1;
        gameOver = levelCompleted = false;
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level");
            }
        }

        if (levelCompleted)
        {      
            LevelPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}
