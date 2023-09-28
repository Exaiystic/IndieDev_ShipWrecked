using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject _newMenu;
    [SerializeField] private GameObject _oldMenu;
    
    public void SwitchMenu()
    {
        _oldMenu.SetActive(false);
        _newMenu.SetActive(true);
    }
}
