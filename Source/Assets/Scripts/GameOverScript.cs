using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public void OnContinueClick()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity", LoadSceneMode.Single);

        //this variables need to be equal to "GameVariables" inital values
        GameVariables.IsGameOver = false;
        GameVariables.WantedLevelValue = 0f;
        GameVariables.Money = 1000f;
        GameVariables.MaxNotoreity = 0f;
        GameVariables.Notoriety = 0f;
    }

public void OnClickExit()
    {
        SceneManager.LoadScene("Assets/Scenes/Main.unity", LoadSceneMode.Single);
    }
}
