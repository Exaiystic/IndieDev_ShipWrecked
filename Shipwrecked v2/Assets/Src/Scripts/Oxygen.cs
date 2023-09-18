using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public int baseOxygen = 100000;
    public int jetpackUsage;
    public int currentOxygen;

    private bool usingJetpack;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = baseOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        usingJetpack = Input.GetButton("Fire2");

        if (usingJetpack)
        {
            currentOxygen = currentOxygen - jetpackUsage;
        }

        if (currentOxygen <= 0)
        {
            FindObjectOfType<GameManager>().gameLose();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        currentOxygen--;
    }

    public void gainOxygen(int amount)
    {
        currentOxygen += amount;
    }
}
