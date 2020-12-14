using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour,IHurtsPlayer {
    [SerializeField]
    Animator animator;

    public int degatsPris;
    public int vie;
    public string objTag;
    public string animationMort;
    public bool AnimationPresente;
    public GameObject objetMereADetruire;

    public bool Alive
    {
        get
        {
            return vie > 0;
        }
    }

    // Use this for initialization
    void Start () {
        //animator = GetComponent<Animator>();
    }

    private void Vie(int degatsPris)
    {
        //Debug.Log("degatsPris");
        vie = vie - degatsPris;
        if (vie <= 0 )
        {
            if(AnimationPresente == true)
            {
                animator.SetBool("SkeletonDeath",true);
                objetMereADetruire.GetComponent<EnnemieIA>().Activate(this.gameObject);

            }
            else
                objetMereADetruire.SetActive(false);

        }
         

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == objTag)
        {
            //Debug.Log("collision");
            dashManager manager = other.gameObject.GetComponent<dashManager>();
            if(manager.IsDashing)
                Vie(degatsPris);
        }
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
