using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationReceiver : MonoBehaviour {

    [SerializeField]
    List<GameObject> sources = new List<GameObject>();


	// Use this for initialization
	void Start () {
		foreach(GameObject source in sources)
        {
            source.GetComponent<AttackActivator>().OnActivation += ReceiveActivation;
        }
	}

    private void ReceiveActivation(GameObject sender)
    {
        Debug.Log(this.gameObject.name + " : Received activation event");
        foreach(GameObject s in sources)
        {

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
