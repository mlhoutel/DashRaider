using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour,IHurtsPlayer {

    [SerializeField]
    public float moveSpeed;

    public Vector3 moveDirection;

    public bool Alive
    {
        get
        {
            return true;
        }
    }

    // Use this for initialization

    void Start () {
		
	} 

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () { 
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
	}
}
