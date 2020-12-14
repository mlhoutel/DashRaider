using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("StartGameInstance", 0.1f);
    }

    public void StartGameInstance()
    {
        FloorManager.StartGame();
    }

    public static void StartGame()
    {
        GameData.gameStarted = true;
    }
	
    public static void ResetRoom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ResetFloor()
    {
        GameData.gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
