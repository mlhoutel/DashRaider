using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreVie : MonoBehaviour {
    public float ValeurMax = 10f;
    public float Valeur;
    public RectTransform test;
    [SerializeField]
    dashManager manager;
    [SerializeField]
    float vitesseUpdate = 0.3f;
    float vitesse = 0f;
    // Use this for initialization
	void Start () {
		test = this.GetComponent<RectTransform>();
        manager.OnLoad += ManagerLoaded;
    }

    private void ManagerLoaded(object sender)
    {
        Valeur = manager.DashCount;
        ValeurMax = manager.MaxDashCount;
    }


    // Update is called once per frame
    void Update ()
    {
        Valeur = manager.DashCount;
        ValeurMax = manager.MaxDashCount;


        test.localScale = new Vector3(Mathf.SmoothDamp(test.localScale.x, 7 * (Valeur/manager.MaxDashCount),ref vitesse,vitesseUpdate), 1.2f, 1f);
        //Actualisation de l'affichage


    }
}
