using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour, IPickups
{
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        if (_gameManager == null)
        {
            GameObject managerObject = GameObject.Find("Game Manager");
            _gameManager = managerObject.GetComponent<GameManager>();

            if (_gameManager != null) { return; }
            else { Debug.Log("ERROR - GameManager could not be found"); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IPickedUp();
        }
    }

    public void IPickedUp()
    {
        _gameManager.ObjectivePickedUp();

        Destroy(gameObject);
    }
}
