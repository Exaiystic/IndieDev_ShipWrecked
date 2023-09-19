using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Settings - General")]
    [SerializeField] private GameObject _baseMenu;
    
    [Header("Settings - PlayButton")]
    [SerializeField] private string _sceneName;
    [SerializeField] private GameObject _loadingMenu;

    [Header("Settings - HowToPlayButton")]
    [SerializeField] private GameObject _howToPlayMenu;
    
    public void OnPlay()
    {
        SwitchMenu(_baseMenu, _loadingMenu);
        
        SceneManager.LoadScene(_sceneName);
    }

    public void OnHowToPlayPressed()
    {
        SwitchMenu(_baseMenu, _howToPlayMenu);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        SwitchMenu(_howToPlayMenu, _baseMenu);
    }

    private void SwitchMenu(GameObject activeMenu, GameObject targetMenu)
    {
        if (activeMenu != null)
        {
            activeMenu.SetActive(false);

            if (targetMenu != null)
            {
                targetMenu.SetActive(true);
            }
        }
    }
}
