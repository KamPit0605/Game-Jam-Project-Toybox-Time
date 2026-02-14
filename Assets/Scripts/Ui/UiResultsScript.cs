using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UiResultsScript : MonoBehaviour
{
    public TextMeshProUGUI scoreResultsText;
    public TextMeshProUGUI stopwatchResultsText;
    [SerializeField] private GameObject ResultsText;
    public TextMeshProUGUI previousRecordResultsText;

    public bool isNewRecord;
    public float RecordTextTimer = 1f;

    void Start()
    {
        scoreResultsText.text = PublicStatic.ResultsScore.ToString();
        stopwatchResultsText.text = PublicStatic.ResultsStopwatch.ToString("0.00");
        
        isNewRecord = false;
    }

    void Update()
    {
        RecordTextTimer -= Time.deltaTime;
        if (RecordTextTimer <= 0) {RecordTextTimer = 0;}

        ResultsResults();
    }

    public void ResultsResults()
    {

        ResultsText.SetActive(true);

        if (PublicStatic.ResultsScore> PublicStatic.ResultsRecordScore)
        {
            PublicStatic.ResultsRecordScore = PublicStatic.ResultsScore;
            isNewRecord = true;
        }
        else
        {
            previousRecordResultsText.text = "Previous Record: " + PublicStatic.ResultsRecordScore;
        }
        //ResultTimer = 0;
    }

}
