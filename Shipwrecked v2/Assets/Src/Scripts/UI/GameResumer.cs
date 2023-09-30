using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResumer : MonoBehaviour
{
    public void ResumeGame()
    {
        if (GameManager.current != null)
        {
            EventManager.current.TogglePause();
        }
    }
}
