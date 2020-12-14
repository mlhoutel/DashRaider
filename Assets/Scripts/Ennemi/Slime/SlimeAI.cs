using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeAI : MonoBehaviour,IActivatable,IHurtsPlayer {

    bool enabledAI = false;
    GameObject target;
    [SerializeField]
    float speed = 4f;
    [SerializeField]
    Animator animator;

    [SerializeField]
    Light slimeLight;
    [SerializeField]
    float deadLightIntensity = 0.5f;
    float lightSpeed = 0;
    [SerializeField]
    float lightUpdateTime = 1f;

    NavMeshAgent navMeshAgent;

    public event EventHandlers.ActivationManager OnActivation;
    
    bool activated = false;
    [HideInInspector]
    public bool dead = false;

    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

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

    public bool Alive
    {
        get
        {
            return !dead;
        }
    }


    // Use this for initialization
    void Start () {
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>(), this.GetComponent<BoxCollider>());
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.Warp(transform.position);
	}

    public void Trigger(GameObject target)
    {
        //Debug.Log("TRIGGERED");
        this.Target = target;
        this.enabledAI = true;
        if(animator != null)
            animator.SetBool("Moving", true);
    }
	
	// Update is called once per frame
	void Update () {
        if(enabledAI)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * speed);
            
            navMeshAgent.destination = Target.transform.position;
        }
        else
        {
            if (!navMeshAgent.enabled)
                navMeshAgent.isStopped = true;
        }

        if(dead)
        {
            this.slimeLight.intensity = Mathf.SmoothDamp(slimeLight.intensity, deadLightIntensity, ref lightSpeed, lightUpdateTime);
        }
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (!dead && other.gameObject.tag == "Player")
        {
            //Debug.Log("trigger");
            dashManager manager = other.gameObject.GetComponent<dashManager>();
            if(manager.IsDashing)
            {
                this.Activate(this.gameObject);
                
            }
        }

    }

   

    public void Activate(GameObject sender)
    {
        Debug.Log("activation sent from "+sender.name);
        this.dead = true;
        this.enabledAI = false;
        this.Activated = true;
        if (animator != null)
            animator.SetBool("Dead", true);
        if (OnActivation != null)
            this.OnActivation.Invoke(this.gameObject);
    }
}
