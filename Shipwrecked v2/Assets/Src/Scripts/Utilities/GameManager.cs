using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float restartDelay;
    public int objectivesLeft;
    [SerializeField] private DisplayText _objectivesUI;

    public static GameManager current;

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
        }
    }

    public void gameWin()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Win!");
        }
    }
}
