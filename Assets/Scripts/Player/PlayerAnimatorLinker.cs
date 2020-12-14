using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorLinker : MonoBehaviour {

    Animator animator;
    dashManager manager;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        manager = GetComponentInParent<dashManager>();
	}

    public void ActivateDash()
    {

        manager.ActivateDash();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
