using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAITrigger : MonoBehaviour {

    SlimeAI AI;

	// Use this for initialization
	void Start () {
        AI = GetComponentInParent<SlimeAI>();
	}

    private void OnTriggerStay(Collider other)
    {
        if(!AI.dead && other.gameObject.tag == "Player")
        {
            AI.Trigger(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
