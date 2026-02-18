using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class PublicScripts : MonoBehaviour
{
    
    public UiClass UiClass;
    public PlayerScript PlayerScript;
    private GameObject[] PlayerLocks;

    public float timer;
    public float stopwatch;
    public bool runTimer;
    public bool runStopwatch;
    private float timeExtensionLimit;
    //private float timeDuration = 3f * 60f;
    public float itemSpawnTimer; //COUNTS UP until the time to spawn an object
    public float itemSpawnTimerMax = 10; //The max time for "itemSpawnTimer" to count up (created static variable for other scripts)
    public bool itemSpawned = false;

    public int score;
    public int scoreQuota; //*The goal or win condition
    public float SecondsAddedTextTimer;
    [SerializeField] private bool canScore;

    public float ResultTimer;
    public int ResultObject;
    public bool ResultShow;
    public bool isNewRecord;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI stopwatchText;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI scoreResultsText;
    public TextMeshProUGUI stopwatchResultsText;
    [SerializeField] private GameObject ResultsText;
    public TextMeshProUGUI previousRecordResultsText;

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

        PlayerLocks = GameObject.FindGameObjectsWithTag("PlayerLock");
        Time.timeScale = 1f;
        PopInTextTimer = 1f;
        ResultTimer = 3f;
        ResultShow = false;
        isNewRecord = false;
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
        ResultsText.SetActive(false);
        canScore = true;

    }

    // Update is called once per frame
    void Update()
    {
        TimerTimer();
        timerText.text = timer.ToString("0.00");
        stopwatchText.text = stopwatch.ToString("0.00");
        scoreText.text = score.ToString();
        scoreResultsText.text = score.ToString();
        stopwatchResultsText.text = stopwatch.ToString("0.00");

        if (PlayerScript.jumpPressed == true)
        {
            EnableTimer();
            if (StartTextTimer > 0)
            {
                StartTextObject.SetActive(true);
                foreach (GameObject PLocks in PlayerLocks) { PLocks.SetActive(false); }

            }

        }

        PopInTexts();
        ResultsResults();
        //Scoring();
    }


    void TimerTimer()
    {
        if (runTimer == true)
        {
            StartTextTimer -= Time.deltaTime;
            PopInTextTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 5f) { timerText.color = Color.red; }
            else { timerText.color = Color.white; }
        }
        if (timer <= 0f) 
        {
            timer = 0f;
            runTimer = false;
            runStopwatch = false;
            canScore = false;
            ResultTimer -= Time.deltaTime;
            ScoreSyncing();
            if (ResultTimer <= 0 && ResultShow == false) {ResultShow = true;}
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
            if (itemSpawnTimer >= itemSpawnTimerMax) 
            {
                itemSpawned = true;
                //if (itemSpawned == true) { itemSpawnTimer = 0f; }
            }

        }

    }

    public void Scoring()
    {
        if (canScore)
        {
            string Seconds = " Seconds";
            PopInTextTimer = 1f;
            score++;
            timer = timer + timeExtensionLimit;
            SecondsAddedTextObject.SetActive(true);
            if (timeExtensionLimit == 1) { Seconds = " Second"; }
            SecondsAdddedText.text = "+" + timeExtensionLimit + Seconds;
        }
    }

    public void ScoreSyncing()
    {
        PublicStatic.ResultsScore = score;
        PublicStatic.ResultsStopwatch = stopwatch;
    }

    public void EnableTimer()
    {
        runTimer = true;
        runStopwatch = true;
        ReadyTextObject.SetActive(false);
    }

    public void ResultsResults()
    {
        return;
        /*if (ResultShow == true)
        {
            PublicStatic.ResultsScore = score;
            PublicStatic.ResultsStopwatch = stopwatch;
            
            ResultsText.SetActive(true);
            FinishTextObject.SetActive(false);
            
            if (score > PublicStatic.ResultsRecordScore)
            {
                PublicStatic.ResultsRecordScore = score;
                isNewRecord = true;
            }
            else
            {
                previousRecordResultsText.text = "Previous Record: " + PublicStatic.ResultsRecordScore;
            }
            ResultTimer = 0; 
        }
        */
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

        if ((timer <= 0f) && (ResultShow == false))
        {
            FinishTextObject.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
}
