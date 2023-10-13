using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [Header("Settings - Thrusters")]
    [SerializeField] private float _fuelConsumption = 50f;
    [SerializeField] private float _thrustPower = 100f;
    [SerializeField] private float _maxThrustPower = 15f;

    [Header("Settings - Tilt")]
    [SerializeField] private float _tiltAngle = 45f;

    [Header("Settings - References")]
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private Oxygen _oxygen;
    [SerializeField] private ParticleSystem _jetpackParticles;

    private bool _bThrusting = false;

    void Update()
    {
        if (_oxygen == null) { return; }

        JetpackUpdate();
        JetpackFX();
    }

    private void FixedUpdate()
    {
        if (_rigidBody2D == null) { return; }

        JetpackFixedUpdate();
    }

    private void JetpackUpdate()
    {
        //Rotating the jetpack
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * _tiltAngle));

        //Using the thrusters if Fire1 is being pressed
        if (Input.GetButton("Fire1"))
        {
            //Jetpack being used...
            _oxygen.ChangeDecayRate(_fuelConsumption);
            _bThrusting = true;
        }
        else
        {
            _oxygen.ResetDecayRate();
            _bThrusting = false;
        }
    }

    private void JetpackFixedUpdate()
    {
        if (_bThrusting)
        {
            _rigidBody2D.AddForce(transform.up * _thrustPower);
            _rigidBody2D.velocity = Vector2.ClampMagnitude(_rigidBody2D.velocity, _maxThrustPower);
        }
    }

    private void JetpackFX()
    {
        if (_jetpackParticles == null) return;

        if (_bThrusting && !_jetpackParticles.isEmitting) _jetpackParticles.Play();
    }
}
