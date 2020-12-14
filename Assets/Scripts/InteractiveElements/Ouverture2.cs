using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouverture2 : MonoBehaviour {

    private Animator Anim;

	// Use this for initialization
	void Start () {

        Anim = GameObject.Find("Porte").GetComponent<Animator>();

		
	}
    private void OnTriggerEnter()
    {
        Anim.SetBool("Open", true);
        
    }

    private void OnTriggerExit()
    {
        Anim.SetBool("Open", false); 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
