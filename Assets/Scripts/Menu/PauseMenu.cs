using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    KeyCode PauseKey = KeyCode.Escape;
    public static bool paused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        if (paused) Pause();
        else Resume();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(PauseKey))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void OpenOptions()
    {
        GameData.previousSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void ResetFloor()
    {
        GameData.gameStarted = false;
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMain()
    {
        GameData.gameStarted = false;
        Resume();
        SceneManager.LoadScene(0);
    }

}
