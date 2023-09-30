using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject _playUI;
    [SerializeField] private GameObject _pauseUI;
    
    private bool _bPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.OnPauseToggle += SwitchUI;
    }

    private void SwitchUI()
    {
        if (_bPaused) { _bPaused = false; } 
        else { _bPaused = true; }

        _playUI.SetActive(!_bPaused);
        _pauseUI.SetActive(_bPaused);
    }
}
