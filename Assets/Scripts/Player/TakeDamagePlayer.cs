using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamagePlayer : MonoBehaviour {

    public event EventHandlers.ActivationManager OnDamageTaken;
    public event EventHandlers.ActivationManager OnLoad;

    public int vie = 3;
    [HideInInspector]
    public int maxVie;
    public int dmg = 1;
    public float cooldownTime = 0.6f;
    float cooldown = 0;
    dashManager manager;
    [SerializeField]
    GameObject Cam;

	// Use this for initialization
	void Start () {
        maxVie = vie;
        manager = GetComponent<dashManager>();
        if (GameData.gameStarted)
        {
            vie = GameData.vie;
        }
        else
        {
            GameData.vie = vie;
        }
        //Debug.Log(vie);
        if (OnLoad != null) OnLoad.Invoke(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if(cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 0;
        }
        if (vie <= 0) 
        {
            FloorManager.ResetRoom();
        }
	}

    private void OnTriggerStay(Collider other)
    {
        IHurtsPlayer hurts = other.gameObject.GetComponent<IHurtsPlayer>();
        if (cooldown <= 0 && !manager.IsDashing && ((hurts != null && hurts.Alive) || other.gameObject.tag == "HurtPlayer")) 
        {
            if (vie > 0)
            {
                vie -= dmg;
                Cam.GetComponent<CameraShake>().Trauma = 0.4f;
            }

            
            if (OnDamageTaken != null) OnDamageTaken.Invoke(this.gameObject);

            cooldown = cooldownTime;
        }
        
        
    }
}
