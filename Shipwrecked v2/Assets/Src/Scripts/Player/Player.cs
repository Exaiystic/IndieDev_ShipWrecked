using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings - Oxygen")]
    [SerializeField] private float _baseOxygen = 5000f;
    [SerializeField] private float _startingOxygen;
    [SerializeField] private float _neutralOxygenDecayRate = 1f;
    [SerializeField] private float _jetpackOxygenDecayRate = 5f;
    [SerializeField] private DisplayText _oxygenUI;

    [Header("Settings - Jetpack")]
    [SerializeField] private GameObject _jetpack;
    [SerializeField] private float _tiltAngle = 45f;
    [SerializeField] private float _thrustPower = 50f;
    [SerializeField] private float _maxThrustPower = 15f;
    [SerializeField] private Rigidbody2D _rigidBody;

    [Header("Settings - Movement")]
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private float _runSpeed = 50f;

    private float _horizontalMovement = 0f;
    private bool _bJumping = false;
    private bool _bThrusting;
    private float _currentOxygen = 0f;
    private float _currentOxygenDecayRate;

    void Awake()
    {
        if (_rigidBody == null) { _rigidBody = GetComponent<Rigidbody2D>(); }

        if (_characterController == null) { _characterController = GetComponent<CharacterController2D>(); }
    }
    
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
        //Reduces the player's oxygen levels
        OxygenDecay();

        //Rotates the jetpack based off the player's movement
        JetpackRotation();

        Move();

        if (Input.GetButton("Fire1"))
        {
            //Jetpack being used...
            _currentOxygenDecayRate = _jetpackOxygenDecayRate;
            _bThrusting = true;
        } else
        {
            _currentOxygenDecayRate = _neutralOxygenDecayRate;
            _bThrusting = false;
        }
    }

    private void FixedUpdate()
    {
        if (_bThrusting)
        {
            _rigidBody.AddForce(transform.up * _thrustPower);
            _rigidBody.velocity = Vector2.ClampMagnitude(_rigidBody.velocity, _maxThrustPower);
        }

        _characterController.Move(_horizontalMovement, _bJumping);
    }

    private void OxygenDecay()
    {
        _currentOxygen -= _currentOxygenDecayRate * Time.deltaTime;

        if (_oxygenUI != null) { _oxygenUI.UpdateText(_currentOxygen.ToString()); }

        if (_currentOxygen <= 0f) { FindObjectOfType<GameManager>().gameLose(); }
    }

    private void JetpackRotation()
    {
        _jetpack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * _tiltAngle));
    }

    private void Move()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal") * _runSpeed;
        _bJumping = Input.GetButton("Jump");
    }

    public float ReturnCurrentOxygen()
    {
        return _currentOxygen;
    }
}
