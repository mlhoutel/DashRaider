using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    [HideInInspector]
    public GameObject player;
    public Transform spriteOrientation;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(player.transform);
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, spriteOrientation.rotation) as BulletController;
                newBullet.moveDirection = (player.transform.position - transform.position).normalized;
                newBullet.moveSpeed = bulletSpeed;
                
               
            }

        }
        else
        {
            shotCounter = 0;
        }
	}

  




}
