using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonManager : MonoBehaviour {

	
    public void OnBackClick()
    {
        SceneManager.LoadScene(0);
    }
}
