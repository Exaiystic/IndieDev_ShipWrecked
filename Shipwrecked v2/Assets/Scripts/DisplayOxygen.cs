﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOxygen : MonoBehaviour
{
    public GameObject player;
    public Text oxygenUI;

    private float playerOxygen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Oxygen oxygenScript = player.GetComponent<Oxygen>();
        playerOxygen = oxygenScript.currentOxygen;

        oxygenUI.text = playerOxygen.ToString();
    }
}
