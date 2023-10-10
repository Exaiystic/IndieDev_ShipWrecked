using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleUI : MonoBehaviour
{
    private enum SceneState
    {
        Playing,
        Paused,
        Won,
        Failed
    }
    
    [Header("Settings")]
    [SerializeField] private GameObject _playUI;
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private GameObject _loseUI;
    
    private bool _bPaused = false;
    
    //Use an ENUM for handling which state ui to switch to

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.OnPauseToggle += GamePaused;
        EventManager.current.OnGameWin += GameWon;
        EventManager.current.OnGameLose += GameLost;
    }

    private void GamePaused()
    {
        if (_bPaused) 
        { 
            _bPaused = false; 
            SwitchUI(SceneState.Playing); 
        }
        else 
        {
            _bPaused = true; 
            SwitchUI(SceneState.Paused);
        }
    }

    private void GameWon()
    {
        SwitchUI(SceneState.Won);
    }

    private void GameLost()
    {
        SwitchUI(SceneState.Failed);
    }

    private void SwitchUI(SceneState newState)
    {
        if (_playUI != null) { _playUI.SetActive(false); }
        if (_pauseUI != null) { _pauseUI.SetActive(false); }
        if (_winUI != null) { _winUI.SetActive(false); }
        if (_loseUI != null) { _loseUI.SetActive(false); }

        switch (newState)
        {
            case SceneState.Playing:
                if (_playUI != null) { _playUI.SetActive(true); }
                break;
            case SceneState.Paused:
                if (_pauseUI != null) { _pauseUI.SetActive(true); }
                break;
            case SceneState.Won:
                if (_winUI != null) { _winUI.SetActive(true); }
                break;
            case SceneState.Failed:
                if (_loseUI != null) { _loseUI.SetActive(true); }
                break;
            default:
                break;
        }
    }
}
