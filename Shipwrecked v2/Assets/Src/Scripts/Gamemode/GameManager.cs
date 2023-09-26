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
    [SerializeField] private GameObject _pausedUI;

    private GameObject[] objectives;
    private bool gameEnded = false;
    private bool _bPaused = false;

    private void Start()
    {
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
        if (_bPaused)
        {
            Time.timeScale = 1f;
            _bPaused = false;
        } else
        {
            Time.timeScale = 0f;
            _bPaused = true;
        }

        _pausedUI.SetActive(_bPaused);
    }

    private void ObjectivesInit()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        objectivesLeft = objectives.Length;
        
        UpdateObjectives();
    }

    private void UpdateObjectives()
    {
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
