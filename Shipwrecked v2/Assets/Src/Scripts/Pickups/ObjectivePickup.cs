using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickup : Pickup
{
    protected override void PickedUp(GameObject collector)
    {
        EventManager.current.ObjectivePickedUp();

        Destroy(gameObject);
    }
}
