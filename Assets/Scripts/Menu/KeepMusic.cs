using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusic : MonoBehaviour {

    bool set = false;
    
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
        {
            foreach (GameObject go in objs)
            {
                
                if(go.GetComponent<KeepMusic>().set)
                {
                    AudioSource toModify = go.GetComponent<AudioSource>();
                    if (toModify.clip != this.gameObject.GetComponent<AudioSource>().clip)
                    {
                        toModify.clip = GetComponent<AudioSource>().clip;
                        toModify.Play();
                    }
                    Destroy(this.gameObject);
                }
                
                
            }
        }

        this.set = true;
        DontDestroyOnLoad(this.gameObject);
    }
}
