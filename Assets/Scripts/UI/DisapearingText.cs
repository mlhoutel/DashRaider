using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisapearingText : MonoBehaviour {

    [SerializeField]
    float disappearTime = 3f;
    [SerializeField]
    float disappearSpeed = 2f;

    bool disappear = false;

    
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        this.Show();
	}
	
    void Disappear()
    {
        disappear = true;
    }

	// Update is called once per frame
	void Update () {
        if (disappear && text.color.a > 0) 
        {
            (text.color) = new Color(text.color.r, text.color.g, text.color.b, text.color.a - disappearSpeed * Time.deltaTime);
        }
	}

    public void Show(string message)
    {
        text.text = message;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        disappear = false;
        Invoke("Disappear", disappearTime);
    }

    public void Show()
    {
        this.Show(text.text);
    }
}
