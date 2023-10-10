using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private enum LoadAction
    {
        LoadNext,
        ReloadCurrent,
        LoadSpecified 
    }
    
    [Header("Settings")]
    [SerializeField] private LoadAction _loadAction;
    [SerializeField] private string _targetSceneName;

    public void LoadLevel()
    {
        switch (_loadAction)
        {
            case LoadAction.LoadNext:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case LoadAction.ReloadCurrent:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case LoadAction.LoadSpecified:
                SceneManager.LoadScene(_targetSceneName);
                break;
        }
    }
}
