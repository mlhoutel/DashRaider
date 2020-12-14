using UnityEngine;

public class ScriptFPS : MonoBehaviour {

    float deltaTime = 0.0f;
    bool isEnabled = false;
    KeyCode keyShow = KeyCode.F3;
    [SerializeField]
    Font FPSFont;
    [SerializeField]
    int FontSize = 24;
    [SerializeField]
    Vector2 Offset = new Vector2(5,5);
    
    void Start()
    {

    }

    void Update()
    {
        
        if (Input.GetKeyDown(keyShow))
        {
            isEnabled = !isEnabled;
        }
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        if (isEnabled)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(Offset.x, Offset.y, w, h * 2 / 50);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = FontSize;
            style.normal.textColor = new Color(1, 0.92f, 0.016f, 1);
            style.font = FPSFont;
            float fps = 1.0f / deltaTime;
            string text = (int)fps + " fps";
            GUI.Label(rect, text, style);
        }
    }

}