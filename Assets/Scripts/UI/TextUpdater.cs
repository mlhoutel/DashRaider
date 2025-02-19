﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    [SerializeField]
    dashManager manager;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = manager.DashCount.ToString() + " / " + manager.MaxDashCount.ToString();
	}
}
