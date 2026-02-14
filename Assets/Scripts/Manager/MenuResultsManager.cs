using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuResultsManager : MonoBehaviour
{
    [SerializeField] private GameObject ResultsMenu;
    [SerializeField] private GameObject NewRecordText;
    [SerializeField] private GameObject PreviousRecordText;

    [SerializeField] private GameObject PlayAgainFirst;

    public UiResultsScript UiRScript;

    // Start is called before the first frame update
    private void Start()
    {
        ResultsMenu.SetActive(true);
        NewRecordText.SetActive(false);
        PreviousRecordText.SetActive(false);
        EventSystem.current.SetSelectedGameObject(PlayAgainFirst);
    }

    // Update is called once per frame
    private void Update()
    {
        if (UiRScript.RecordTextTimer <= 0f) { Resultss(); }
    }

    public void Resultss()
    {

        if (UiRScript.isNewRecord) { NewRecordText.SetActive(true); }
        else { PreviousRecordText.SetActive(true); }

    }

    //Menus

    public void PlayAgainPress()
    {
        LoadGame("PrototypeScene");
    }

    public void QuitPress()
    {
        Application.Quit();
        Debug.Log("Pretend that you Quitted the game");
    }

    //Loading scenes
    public void LoadGame(string PrototypeScene)
    {
        SceneManager.LoadScene(PrototypeScene);
    }

}
