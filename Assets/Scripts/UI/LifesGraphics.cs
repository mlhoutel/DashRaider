using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesGraphics : MonoBehaviour {

    

    public TakeDamagePlayer degats;

    public List<GameObject> coeurs;
    public int nbcoeurs;
    int heartsMissing;


    private void Awake()
    {
        degats.OnLoad += Degats_OnLoad;
    }

    // Use this for initialization
    void Start () {

        coeurs = new List<GameObject>( GameObject.FindGameObjectsWithTag("coeur"));
        coeurs.Sort((x,y) => (int)(x.transform.position.x - y.transform.position.x));
        
        degats.OnDamageTaken += UpdateHarts;
        for (int i = heartsMissing; i > 0; i--)
        {
            coeurs[coeurs.Count - i].SetActive(false);
        }

        //Debug.Log(coeurs.Count);
        
    }

    private void Degats_OnLoad(GameObject sender)
    {
        //Debug.Log("life graphics : " + coeurs.Count + " " + (degats.maxVie - degats.vie) + " " + (coeurs.Count - (degats.maxVie - degats.vie)));
        heartsMissing = degats.maxVie - degats.vie;
        UpdateHarts(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void UpdateHarts(GameObject sender)
    {
        int count = 0;
        
        nbcoeurs = degats.vie;
        //Debug.Log("Coucou" + nbcoeurs);
        foreach(GameObject c in coeurs)
        { 
            if(count>nbcoeurs)
            {
                c.SetActive(false);
            }
            count++;
        }
        coeurs[nbcoeurs].SetActive(false);
        

    }

    
}
