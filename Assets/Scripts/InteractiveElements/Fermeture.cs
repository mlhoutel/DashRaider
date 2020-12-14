using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fermeture : MonoBehaviour,IActivatable {

    [SerializeField]
    private Animator AnimDoor;
    [SerializeField]
    Animator AnimCheck;
    private GameObject player;
    private bool IsActivated = false;
    [SerializeField]
    private int DashAAvoir;
    [SerializeField]
    DisapearingText text;
    [SerializeField]
    string roomMessage = "N/A";

    public bool Activated
    {
        get
        {
            return IsActivated;
        }
        set
        {
            IsActivated = value;
        }
    }

    public event EventHandlers.ActivationManager OnActivation;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (AnimDoor != null)
                AnimDoor.SetBool("Open", false);

            GameData.positionApparition = new Vector3(transform.position.x, GameData.positionApparition.y , transform.position.z);
            GameData.vie = other.gameObject.GetComponent<TakeDamagePlayer>().vie;

            if (!IsActivated)
            {
                
                player.GetComponent<dashManager>().MaxDashCount = DashAAvoir;
                player.GetComponent<dashManager>().DashCount = DashAAvoir;
                Activate(this.gameObject);
                if (text != null)
                    text.Show(roomMessage);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Activate(GameObject sender)
    {
        AnimCheck.SetTrigger("CheckpointEnable");
        this.Activated = true;
        if (OnActivation != null) OnActivation.Invoke(this.gameObject);
    }
}