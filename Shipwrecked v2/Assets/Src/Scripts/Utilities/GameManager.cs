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
        EventManager.current.OnPauseToggle += FreezeGame;
        EventManager.current.OnObjectivePickedUp += ObjectivePickedUp;

        Time.timeScale = 1f;

        ObjectivesInit();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
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

    private void ObjectivesInit()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        objectivesLeft = objectives.Length;
        
        UpdateObjectives();
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
            StartCoroutine(Restart());
        }
    }

    public void gameWin()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Win!");
            StartCoroutine(Restart());
        }
    }

    protected virtual IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
