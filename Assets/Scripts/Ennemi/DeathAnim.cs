using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{

    Animator deathannim;
    SpriteRenderer deathsprite;
	void Start ()
    {
            //.GetComponent<BoxCollider>();
        deathannim = this.GetComponent<Animator>();
        deathsprite = this.GetComponent<SpriteRenderer>();
        deathannim.enabled = false;
        deathsprite.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (this.GetComponentInParent<IHurtsPlayer>().Alive == false)
        {
            deathannim.enabled = true;
            deathsprite.enabled = true;
        }
	}
}
