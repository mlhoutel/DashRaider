﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {


    public void BackOptions()
    {
        SceneManager.LoadScene(GameData.previousSceneBuildIndex);

    }
}
