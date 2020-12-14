using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActivator : MonoBehaviour, IActivatable
{

    private Animator Anim;
    
    public event EventHandlers.ActivationManager OnActivation;

    bool activated = false;

    public bool Activated
    {
        get
        {
            return activated;
        }

        set
        {
            activated = value;
        }
    }


    // Use this for initialization
    void Start () {
        
	}
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dashManager manager =  other.gameObject.GetComponent<dashManager>();
            if (manager != null) 
            {
                if(!this.Activated && manager.IsDashing)
                {
                    this.Activate(this.gameObject);
                    
                }
            }
        }
    }

    public void Activate(GameObject sender)
    {
        this.Activated = true;
        //Debug.Log(gameObject.name + " : Activated");
        if(OnActivation != null)
            OnActivation.Invoke(this.gameObject);        
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
