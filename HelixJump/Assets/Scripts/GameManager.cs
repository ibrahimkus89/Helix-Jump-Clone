using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject LevelPanel;
    public static int currentLevelIndex;
    [SerializeField] Slider gameSlider;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI nextLevelText;
    public static int numberOfPassedRings;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex",1);
    }

    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        gameOver = levelCompleted = false;
    }

    
    void Update()
    {
        currentLevelText.text =currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HlxManager>().numberOfRings;
        gameSlider.value = progress;


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
                PlayerPrefs.SetInt("CurrentLevelIndex",currentLevelIndex +1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
