using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string _targetSceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_targetSceneName);
    }
}
