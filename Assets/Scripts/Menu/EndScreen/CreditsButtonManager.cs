using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtonManager : MonoBehaviour {

	public void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }
}
