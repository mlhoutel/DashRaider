using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {
    public static int previousSceneBuildIndex = 0;

    public static GameObject player;
    public static Vector3 positionApparition;
    public static int vie = 0;
    public static bool gameStarted = false;

    public static KeyCode BindKeyUp;
    public static KeyCode BindKeyDown;
    public static KeyCode BindKeyLeft;
    public static KeyCode BindKeyRight;
    public static KeyCode BindKeyReset;
}
