using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPickup : Pickup
{
    [Header("Settings")]
    [SerializeField] private int _oxygenGiven = 100;

    protected override void PickedUp(GameObject collector)
    {
        Oxygen oxygen = collector.GetComponent<Oxygen>();
        if (oxygen != null) { oxygen.addOxygen(_oxygenGiven); }
        Destroy(gameObject);
    }
}
