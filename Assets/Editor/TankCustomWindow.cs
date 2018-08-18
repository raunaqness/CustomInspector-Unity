using UnityEditor;
using UnityEngine;

public class TankCustomWindow : EditorWindow {

    Color color;

    [MenuItem("Custom/Colorizer")]
    public static void ShowWindow()
    {
          GetWindow<TankCustomWindow>("Colorizer");          
    }

    void OnGUI()
    {
        GUILayout.Label("Color the selected Objects", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if(GUILayout.Button("Colorize"))
        {
            Colorize();
        }
        
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
