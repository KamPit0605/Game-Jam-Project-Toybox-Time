using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseText;

    [SerializeField] private GameObject ResultsMenu;
    [SerializeField] private GameObject NewRecordText;
    [SerializeField] private GameObject PreviousRecordText;

    [SerializeField] private GameObject ResumeFirst;
    [SerializeField] private GameObject PlayAgainFirst;
    

    public PlayerScript PlayerScript;
    public PublicScripts UiScript;

    private bool Paused;

    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseText.SetActive(false);
        ResultsMenu.SetActive(false);
        NewRecordText.SetActive(false);
        PreviousRecordText.SetActive(false);
    }

    private void Update()
    {
        if (PlayerScript.pausePressed == true)
        {
            if (!Paused) { Pause(); }
            else { Unpause(); }
            PlayerScript.pausePressed = false;
        }
    }

     //Pausing
    public void Pause()
    {
        Paused = true;
        Time.timeScale = 0f; 
        OpenPauseMenu();
    }
    public void Unpause()
    {
        Paused = false;
        Time.timeScale = 1f;
        CloseAllMenus();
    }

    private void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        PauseText.SetActive(true);

        EventSystem.current.SetSelectedGameObject(ResumeFirst);
    }

    private void OpenResults()
    {
        ResultsMenu.SetActive(true);
        if (UiScript.isNewRecord){NewRecordText.SetActive(true);}
        else { PreviousRecordText.SetActive(true); }
        
    }

    private void CloseAllMenus()
    {
        PauseMenu.SetActive(false);
        PauseText.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }
    

     //Menus

    public void ResumePress()
    {
        Unpause();
    }

    public void RestartPress()
    {
        Unpause();
        LoadGame("PrototypeScene");
    }

    public void QuitPress()
    {
        Application.Quit();
        Debug.Log("Pretend that you Quitted the game");
    }

    //Loading scenes
    public void LoadGame (string PrototypeScene)
    {
        SceneManager.LoadScene(PrototypeScene);
    }
}
