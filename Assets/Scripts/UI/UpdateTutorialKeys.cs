using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTutorialKeys : MonoBehaviour {

    [SerializeField] public GameObject TutoMoveTextKeyDown;
    [SerializeField] public GameObject TutoMoveTextKeyRight;
    [SerializeField] public GameObject TutoMoveTextKeyUp;
    [SerializeField] public GameObject TutoMoveTextKeyLeft;
    [SerializeField] public GameObject TutoMoveTextKeyReset;

    public GameObject Player;
    // Use this for initialization
    void Start ()
    {
        TutoMoveTextKeyLeft = GameObject.Find("TutoMoveTextKeyLeft");
        TutoMoveTextKeyRight = GameObject.Find("TutoMoveTextKeyRight");
        TutoMoveTextKeyUp = GameObject.Find("TutoMoveTextKeyForward");
        TutoMoveTextKeyDown = GameObject.Find("TutoMoveTextKeyBackward");
        TutoMoveTextKeyReset = GameObject.Find("TutoResetKey");

        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        TutoMoveTextKeyLeft.GetComponent<TextMesh>().text = Player.GetComponent<PlayerMovements>().StringKeyLeft.ToString();//ValeursApparitionJoueur.BindKeyLeft.ToString();
        TutoMoveTextKeyRight.GetComponent<TextMesh>().text = Player.GetComponent<PlayerMovements>().StringKeyRight.ToString();//ValeursApparitionJoueur.BindKeyRight.ToString();
        TutoMoveTextKeyUp.GetComponent<TextMesh>().text = Player.GetComponent<PlayerMovements>().StringKeyUp.ToString();//ValeursApparitionJoueur.BindKeyUp.ToString();
        TutoMoveTextKeyDown.GetComponent<TextMesh>().text = Player.GetComponent<PlayerMovements>().StringKeyDown.ToString();//ValeursApparitionJoueur.BindKeyDown.ToString();
        TutoMoveTextKeyReset.GetComponent<TextMesh>().text = Player.GetComponent<PlayerMovements>().StringKeyReset.ToString();//ValeursApparitionJoueur.BindKeyDown.ToString();

    }
}
