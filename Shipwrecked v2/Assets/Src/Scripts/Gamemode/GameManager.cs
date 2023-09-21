using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay;
    public int objectivesLeft;

    private GameObject[] objectives;
    private bool gameEnded = false;

    private void Start()
    {
        ObjectivesInit();
    }

    private void ObjectivesInit()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        objectivesLeft = objectives.Length;
        
        UpdateObjectives();
    }

    private void UpdateObjectives()
    {
        if (objectivesLeft == 0) { gameWin(); }
    }

    public void ObjectivePickedUp()
    {
        objectivesLeft--;
        UpdateObjectives();
    }

    public void gameLose()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Died");
            StartCoroutine(Restart());
        }
    }

    public void gameWin()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("You Win!");
            StartCoroutine(Restart());
        }
    }

    protected virtual IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
