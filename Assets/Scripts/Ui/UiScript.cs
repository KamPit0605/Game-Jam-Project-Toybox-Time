using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class PublicScripts : MonoBehaviour
{
    
    public UiClass UiClass;
    public PlayerScript PlayerScript;

    public float timer;
    public float stopwatch;
    public bool runTimer;
    public bool runStopwatch;
    private float timeExtensionLimit;
    //private float timeDuration = 3f * 60f;
    public float itemSpawnTimer;
    public float itemSpawnTimerMax = 10; //created static variable for other scripts
    public bool itemSpawned = false;

    public int score;
    public int scoreQuota; //*The goal or win condition
    public float SecondsAddedTextTimer;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI stopwatchText;
    public TextMeshProUGUI scoreText;

    [SerializeField] private GameObject StartTextObject;
    [SerializeField] private GameObject FinishTextObject;
    [SerializeField] private GameObject ReadyTextObject;
    public TextMeshProUGUI SecondsAdddedText;
    [SerializeField] private GameObject SecondsAddedTextObject;
    //[SerializeField] private GameObject PauseTextObject;

    public float PopInTextTimer = 1f;
    public float StartTextTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        PopInTextTimer = 1f;
        timer = UiClass.timerSet;
        scoreQuota = UiClass.scoreQuota;
        runTimer = false;
        runStopwatch = false;
        //scoreText.text = score.ToString();
        //timerText.text = timer.ToString();
        ReadyTextObject.SetActive(true);
        StartTextObject.SetActive(false);
        FinishTextObject.SetActive(false);
        SecondsAddedTextObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        TimerTimer();
        timerText.text = timer.ToString("0.00");
        stopwatchText.text = stopwatch.ToString("0.00");
        scoreText.text = score.ToString();

        if (PlayerScript.jumpPressed == true)
        {
            EnableTimer();
            StartTextObject.SetActive(true);
        }

        PopInTexts();
        //Scoring();
    }


    void TimerTimer()
    {
        if (runTimer == true)
        {
            StartTextTimer -= Time.deltaTime;
            PopInTextTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 5f) {timerText.color = Color.red;}
            else {timerText.color = Color.white;}

            if (timer <= 0f) 
            {
                timer = 0f;
                runTimer = false;
                runStopwatch = false;

            }
        }

        if (runStopwatch == true)
        {
            stopwatch += Time.deltaTime;
            if (stopwatch <= 15f) { timeExtensionLimit = 10f; }
            else if (stopwatch <= 30f) { timeExtensionLimit = 5f; }
            else if (stopwatch <= 60f) { timeExtensionLimit = 3f; }
            else if (stopwatch <= 90f) { timeExtensionLimit = 1.5f; }
            else if (stopwatch >= 100f) { timeExtensionLimit = 1; }

            itemSpawnTimer += Time.deltaTime;
            if (itemSpawnTimer >= 10f) 
            {
                itemSpawned = true;
                //if (itemSpawned == true) { itemSpawnTimer = 0f; }
            }

        }

    }

    public void Scoring()
    {
        string Seconds = " Seconds";
        PopInTextTimer = 1f;
        score++;
        timer = timer + timeExtensionLimit;
        SecondsAddedTextObject.SetActive(true);
        if (timeExtensionLimit == 1) { Seconds = " Second"; }
        SecondsAdddedText.text = "+" + timeExtensionLimit + Seconds;
    }

    public void EnableTimer()
    {
        runTimer = true;
        runStopwatch = true;
        ReadyTextObject.SetActive(false);
    }

    void PopInTexts()
    {
        if (PopInTextTimer <= 0f)
        {
            PopInTextTimer = 0f;
            SecondsAddedTextObject.SetActive(false);
        }
        if (StartTextTimer <= 0f) 
        { 
            StartTextObject.SetActive(false);
            StartTextTimer = 0f;
        }

        if (timer <= 0f)
        {
            FinishTextObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
