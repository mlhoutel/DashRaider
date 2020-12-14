using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReceiver : MonoBehaviour
{

    [SerializeField]
    List<GameObject> sources = new List<GameObject>();
    Animator animator;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (GameObject source in sources)
        {
            if (source != null)
                if (source.GetComponent<IActivatable>() == null) Debug.LogError(source.name + " doesn't have Iactivatable",source);
                else source.GetComponent<IActivatable>().OnActivation += ReceiveActivation;
        }
    }

    private void ReceiveActivation(GameObject sender)
    {

        Debug.Log(this.gameObject.name + " : Received activation event from " + sender.name);
        foreach (GameObject s in sources)
        {
            try
            {
                IActivatable a = s.GetComponent<IActivatable>();

                if (!a.Activated)
                {
                    return;
                }
            }
            catch (NullReferenceException)
            { }
            
        }
        animator.SetBool("Open", true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
