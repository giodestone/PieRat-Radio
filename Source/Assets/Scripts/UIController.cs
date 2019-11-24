using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    // Use this for initialization
    void Start () {
	    if (!gameCanvas)
        {
            Debug.LogError("You forgot to set a reference to the Game Canvas!");
        }

        if (!gameOverCanvas)
        {
            Debug.LogError("You forgot to set a reference to the Game Over Canvas!");
        }
	}

    private void LateUpdate()
    {
        if (!GameVariables.IsGameOver)
        {
            //GameObject gameCanvas = GameObject.FindGameObjectWithTag("UIGameCanvas");
            //GameObject gameCanvas = GameObject.Find("Game");
            gameCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
        }
        else if (GameVariables.IsGameOver)
        {
            //GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("UIGameOverCanvas");
            //GameObject gameOverCanvas = GameObject.Find("GameOver");
            gameOverCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }
    }
}
