using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute =false;

    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject LevelPanel;
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] GameObject startMenuPanel;


    public static int currentLevelIndex;
    [SerializeField] Slider gameSlider;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI nextLevelText;
    public static int numberOfPassedRings;
    public static int Score =0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex",1);
    }

    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore",0);
       isGameStarted= gameOver = levelCompleted = false;
    }

    
    void Update()
    {
        currentLevelText.text =currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HlxManager>().numberOfRings;
        gameSlider.value = progress;

        scoreText.text =Score.ToString();

        if (Input.touchCount > 0 &&Input.GetTouch(0).phase ==TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }


        if (gameOver)
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if (Score > PlayerPrefs.GetInt("HighScore",0))
                {
                    PlayerPrefs.SetInt("HighScore",Score);
                }

                Score = 0;
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
