using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    float EnableTime, DisableTime;
    float timer;
    bool isActive;
    public GameObject lightAdd;
    void Start()
    {
        if (EnableTime == 0.0f)
        {
            EnableTime = 5;
            Debug.Log(this.gameObject.name + " : EnableTime est null");
        }
        if (DisableTime == 0.0f)
        {
            DisableTime = 5;
            Debug.Log(this.gameObject.name + " : DisableTime est null");
        }
        timer = Time.time;
        isActive = true;
    }

    void Update()
    {
        //disable
        if (Time.time >= timer + EnableTime && isActive)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            lightAdd.SetActive(false);
            isActive = false;
            timer = Time.time;
        }
        //enable
        if (Time.time >= timer + DisableTime && !isActive)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            lightAdd.SetActive(true);
            isActive = true;
            timer = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bas tu meurt");
    }
}
