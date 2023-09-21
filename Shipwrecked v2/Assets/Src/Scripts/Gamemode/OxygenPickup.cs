using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPickup : MonoBehaviour
{
    public int oxygenGiven = 100;

    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickup();
        }
    }

    private void pickup()
    {
        FindObjectOfType<Oxygen>().gainOxygen(oxygenGiven);
        Destroy(gameObject);
    }
}
