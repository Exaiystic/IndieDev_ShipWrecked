using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings - Gamemode")]
    [SerializeField] private float restartDelay;
    public int objectivesLeft;

    [Header("Settings - UI")]
    [SerializeField] private DisplayText _objectivesUI;
    [SerializeField] private DisplayText _timeUI;
    [SerializeField] private DisplayText _gameEndTimeUI;

    public static GameManager current;

    private float _time = 0f;
    private GameObject[] objectives;
    private bool gameEnded = false;
    private bool _bPaused = false;

    private void Awake()
    {
        current = this;
    }
    
    private void Start()
    {
        GameManagerInit();
    }

    private void Update()
    {
        Timer();
        
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }

    private void GameManagerInit()
    {
        //Setting up events
        EventManager.current.OnPauseToggle += FreezeGame;
        EventManager.current.OnObjectivePickedUp += ObjectivePickedUp;

        //Resetting the time scale in the case that the level was loaded from a pause - and therefore a timescale of 0
        Time.timeScale = 1f;

        //Finding how many objectives there are in the level
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        objectivesLeft = objectives.Length;

        //Updating the objectives ui
        UpdateObjectives();
    }

    private void Timer()
    {
        if (_timeUI == null) { return; }
        _time += Time.deltaTime;

        _time = Mathf.Round(_time * 100) * 0.01f;
        _timeUI.UpdateText(_time.ToString());
    }

    private void Pause()
    {
        EventManager.current.TogglePause();
    }

    private void FreezeGame()
    {
        if (_bPaused)
        {
            Time.timeScale = 1f;
            _bPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            _bPaused = true;
        }
    }

    private void UpdateObjectives()
    {
        if (_objectivesUI != null) { _objectivesUI.UpdateText(objectivesLeft.ToString()); }
        
        if (objectivesLeft == 0) { gameWin(); }
    }

    public void ObjectivePickedUp()
    {
        objectivesLeft--;
        UpdateObjectives();
    }

    public void gameLose()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Died");

            EventManager.current.GameLose();
        }
    }

    public void gameWin()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Win!");

            EventManager.current.GameWin();

            if (_gameEndTimeUI != null) { _gameEndTimeUI.UpdateText(_time.ToString()); }
        }
    }
}
