using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimationLinker : MonoBehaviour {

    AttackActivator activator;
    Animator animator;

	// Use this for initialization
	void Start () {
        activator = GetComponent<AttackActivator>();
        animator = GetComponentInChildren<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (activator.Activated) animator.SetBool("Activated", true);
	}
}
