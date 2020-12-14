using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyBindScript : MonoBehaviour {

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text up, down, left, right, reset;
    private GameObject currentKey;
    private Color32 normal = new Color(39,171,249,255);
    private Color32 selected = new Color32(239, 116, 36, 255);
    void Start ()
    {
        //GameData.BindKeyUp = KeyCode.Z;
        //GameData.BindKeyDown = KeyCode.S;
        //GameData.BindKeyLeft = KeyCode.Q;
        //GameData.BindKeyRight = KeyCode.D;
        //GameData.BindKeyReset = KeyCode.R;

        if (GameData.BindKeyUp == KeyCode.None) GameData.BindKeyUp = KeyCode.Z;
        if (GameData.BindKeyDown == KeyCode.None) GameData.BindKeyDown = KeyCode.S;
        if (GameData.BindKeyLeft == KeyCode.None) GameData.BindKeyLeft = KeyCode.Q;
        if (GameData.BindKeyRight == KeyCode.None) GameData.BindKeyRight = KeyCode.D;
        if (GameData.BindKeyReset == KeyCode.None) GameData.BindKeyReset = KeyCode.R;

        keys["Up"] = GameData.BindKeyUp;
        keys["Down"] = GameData.BindKeyDown;
        keys["Left"] = GameData.BindKeyLeft;
        keys["Right"] = GameData.BindKeyRight;
        keys["Reset"] = GameData.BindKeyReset;

        /*
        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "Z")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "Q")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Reset", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reset", "R")));
        */

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        reset.text = keys["Reset"].ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnGUI()
    {
        if(currentKey!=null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey!=null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }

    public void SaveKeys()
    {
        GameData.BindKeyUp = keys["Up"];
        GameData.BindKeyDown = keys["Down"];
        GameData.BindKeyLeft = keys["Left"];
        GameData.BindKeyRight = keys["Right"];
        GameData.BindKeyReset = keys["Reset"];

        PlayerPrefs.Save();
    }
}
