using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieIA : MonoBehaviour,IActivatable {

    
    Animator animator;

    public GunController theGun;
    //public GameObject player;

    public string Firing;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //  player = GameObject.FindWithTag("player");
    }

    float xNewRot, yNewRot, zNewRot;
    int randNumber;

    bool activated = false;

    public bool Activated
    {
        get
        {
            return this.activated;
        }
        set
        {
            this.activated = value;
        }
    }

    public event EventHandlers.ActivationManager OnActivation;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            animator.SetTrigger(Firing);
        }
    }

    public void SkeletonFire()
    {
        StartCoroutine(NombreDattkParSec());
    }

    // Update is called once per frame
    void Update () {
        
      //  randNumber = Random.Range(1, randShot);
       // this.transform.LookAt(player.transform);

    }

    


    IEnumerator NombreDattkParSec()
    {

        theGun.isFiring = true;
        yield return new WaitForSeconds(1);
        theGun.isFiring = false;

    }

    public void Activate(GameObject sender)
    {
        this.Activated = true;
        if (OnActivation != null)
            OnActivation.Invoke(this.gameObject);
    }
}
