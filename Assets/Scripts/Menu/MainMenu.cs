using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        if (GameData.BindKeyUp == KeyCode.None) GameData.BindKeyUp = KeyCode.Z;
        if (GameData.BindKeyDown == KeyCode.None) GameData.BindKeyDown = KeyCode.S;
        if (GameData.BindKeyLeft == KeyCode.None) GameData.BindKeyLeft = KeyCode.Q;
        if (GameData.BindKeyRight == KeyCode.None) GameData.BindKeyRight = KeyCode.D;
        if (GameData.BindKeyReset == KeyCode.None) GameData.BindKeyReset = KeyCode.R;
    }

    public void PlayGame()
    {
        GameData.gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void QuitGame()
    {
        //Debug.Log("QUIT !!!!!");
        Application.Quit();

    }

    public void Options()
    {
        GameData.previousSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

	
}
