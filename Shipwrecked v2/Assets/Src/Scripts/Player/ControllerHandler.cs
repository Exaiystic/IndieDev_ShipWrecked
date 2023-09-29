using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    [Header("Settings - Movement")]
    [SerializeField] private float _runSpeed = 50f;

    [Header("Settings - References")]
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private float _horizontalMovement = 0f;
    private bool _bJumping = false;

    private void Awake()
    {
        if (_rigidbody2D == null) { _rigidbody2D = GetComponent<Rigidbody2D>(); }

        if (_characterController == null) { _characterController = GetComponent<CharacterController2D>(); }
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal") * _runSpeed;
        _bJumping = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _characterController.Move(_horizontalMovement, _bJumping);
    }
}
