using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObjectives : MonoBehaviour
{
    public Text objectiveUI;
    public GameObject gameManager;

    private GameManager manager;
    private int objectivesLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        objectivesLeft = manager.objectivesLeft;
        objectiveUI.text = objectivesLeft.ToString();
    }
}
