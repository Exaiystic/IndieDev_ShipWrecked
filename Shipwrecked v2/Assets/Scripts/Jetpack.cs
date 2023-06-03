﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jetpackPower = 50f;
    public float maxSpeed;
    public GameObject player;

    private bool thrust = false;

    // Update is called once per frame
    void Update()
    {
        thrust = Input.GetButton("Fire2");

        if (thrust)
        {
            rb.AddForce(transform.up * jetpackPower);
        }
    }

    private void FixedUpdate()
    {
        thrust = false;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
