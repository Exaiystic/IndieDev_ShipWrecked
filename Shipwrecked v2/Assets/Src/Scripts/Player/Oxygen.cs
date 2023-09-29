using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [Header("Settings - Oxygen")]
    [SerializeField] private float _baseOxygen = 5000f;
    [SerializeField] private float _startingOxygen;
    [SerializeField] private float _neutralOxygenDecayRate = 1f;
    [SerializeField] private DisplayText _oxygenUI;

    private float _currentOxygen = 0f;
    private float _currentOxygenDecayRate;

    // Start is called before the first frame update
    void Start()
    {
        if (_startingOxygen == 0)
        {
            _currentOxygen = _baseOxygen;
        }
        else
        {
            _currentOxygen = _startingOxygen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OxygenDecay();
    }

    private void OxygenDecay()
    {
        _currentOxygen -= _currentOxygenDecayRate * Time.deltaTime;

        if (_oxygenUI != null) { _oxygenUI.UpdateText(_currentOxygen.ToString()); }

        if (_currentOxygen <= 0f) { FindObjectOfType<GameManager>().gameLose(); }
    }

    public void addOxygen(int amount)
    {
        _currentOxygen += amount;
    }

    public void ChangeDecayRate(float newDecay)
    {
        _currentOxygenDecayRate = newDecay;
    }

    public void ResetDecayRate()
    {
        _currentOxygenDecayRate = _neutralOxygenDecayRate;
    }
}
