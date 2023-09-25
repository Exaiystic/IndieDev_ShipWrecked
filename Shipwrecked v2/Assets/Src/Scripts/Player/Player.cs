using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _baseOxygen = 5000f;
    [SerializeField] private float _startingOxygen;
    [SerializeField] private float _neutralOxygenDecayRate = 1f;
    [SerializeField] private float _jetpackOxygenDecayRate = 5f;

    private float _currentOxygen = 0f;
    private float _currentOxygenDecayRate;

    // Start is called before the first frame update
    void Start()
    {
        if (_startingOxygen == 0)
        {
            _currentOxygen = _baseOxygen;
        } else
        {
            _currentOxygen = _startingOxygen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OxygenDecay();
        
        if (Input.GetButton("Fire1"))
        {
            //Jetpack being used...
            _currentOxygenDecayRate = _jetpackOxygenDecayRate;
        } else
        {
            _currentOxygenDecayRate = _neutralOxygenDecayRate;
        }
    }

    private void OxygenDecay()
    {
        _currentOxygen -= _currentOxygenDecayRate * Time.deltaTime;

        if (_currentOxygen <= 0f)
        {
            FindObjectOfType<GameManager>().gameLose();
        }
    }

    public float ReturnCurrentOxygen()
    {
        return _currentOxygen;
    }
}
