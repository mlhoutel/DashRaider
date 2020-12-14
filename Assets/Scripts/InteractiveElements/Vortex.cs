using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vortex : MonoBehaviour {
    [SerializeField]
    int buildIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameData.gameStarted = false;
        SceneManager.LoadScene(buildIndex);
    }
}
