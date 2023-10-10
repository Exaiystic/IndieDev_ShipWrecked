using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnPauseToggle;
    public void TogglePause()
    {
        if (OnPauseToggle != null) { OnPauseToggle(); }
    }

    public event Action OnObjectivePickedUp;
    public void ObjectivePickedUp()
    {
        if (OnObjectivePickedUp != null) { OnObjectivePickedUp(); }
    }

    public event Action OnGameWin;
    public void GameWin()
    {
        if (OnGameWin != null) { OnGameWin(); }
    }

    public event Action OnGameLose;
    public void GameLose()
    {
        if (OnGameLose != null) { OnGameLose(); }
    }
}