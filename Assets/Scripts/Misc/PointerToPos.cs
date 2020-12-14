using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToPos : MonoBehaviour {
    //A attacher a la camera.

    private WorldPointActionArgs args = new WorldPointActionArgs();

    public delegate void WorldPointActionManager(Object sender, WorldPointActionArgs args);

    public event WorldPointActionManager OnFire;

    // Use this for initialization
    void Start () {
		
	}
	
    public RaycastHit GetMouseRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500);
        return hit;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            RaycastHit hit = GetMouseRaycast();
            args.Set(hit);
            OnFire.Invoke(this, args);
        }
            
	}
}
