using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour,IHurtsPlayer,IActivatable {
    enum Trajectoires { Circulaire,Lineare }

    private bool alive = true;
    private bool activated = false;
    [SerializeField]
    Animator animatorSprite;
    Animator animatorMove;
    [SerializeField]
    Trajectoires AnimationIndex = Trajectoires.Circulaire;
    [SerializeField,Range(0,1)]
    float AnimationOffset = 0.0f;
    [SerializeField]
    float AnimationSpeed = 1;

    public bool Alive
    {
        get
        {
            return this.alive;
        }
        set
        {
            this.alive = value;
            animatorSprite.SetBool("Dead", !value);
            animatorMove.speed = 0;
        }
    }

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

    public void Activate(GameObject sender)
    {
        this.Activated = true;
        this.Alive = false;
        if (OnActivation != null) OnActivation.Invoke(this.gameObject);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            dashManager manager = other.gameObject.GetComponent<dashManager>();
            if (manager.IsDashing) 
            {
                this.Activate(this.gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {
        animatorMove = GetComponent<Animator>();
        animatorMove.SetFloat("Offset", AnimationOffset);
        animatorMove.SetInteger("AnimationIndex", (int)AnimationIndex);
        animatorMove.speed = AnimationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
