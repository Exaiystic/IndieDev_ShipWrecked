using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Text _textElement;
    
    public void UpdateText(string text)
    {
        _textElement.text = text;
    }
}
