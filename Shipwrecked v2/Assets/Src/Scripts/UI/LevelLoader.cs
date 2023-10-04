using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _bLoadNextLevel = false;
    [SerializeField] private string _targetSceneName;

    public void LoadLevel()
    {
        if (_bLoadNextLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene(_targetSceneName);
        }
    }
}
