using UnityEditor;
using UnityEngine;

public class CheatsWindow : EditorWindow
{
    [MenuItem("My Game/Cheats")]
    public static void ShowWindow()
    {
        GetWindow<CheatsWindow>(false, "Cheats", true);
    }

    void OnGUI()
    {
        EditorGUILayout.Toggle("Mute All Sounds", false);
        EditorGUILayout.IntField("Player Lifes", 3);
        EditorGUILayout.TextField("Player Two Name", "John");
    }
}