using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    [SerializeField]
    GameObject target;
    [SerializeField]
    float smoothTime = 1f;
    Vector3 velocity = new Vector3();

	// Use this for initialization
	void Start () {
        //if (ValeursApparitionJoueur.positionApparition != null) transform.position = ValeursApparitionJoueur.positionApparition;
        transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(target!=null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        }
	}
}
