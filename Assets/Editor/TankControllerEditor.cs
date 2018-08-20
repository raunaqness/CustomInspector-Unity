using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TankController))]
public class TankControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        TankController tank = (TankController)target;

        float ThumbnailWidth = 100f;
        float ThumbnailHeight = 75;

        float LabelWidth = 150f;

        GUILayout.Space(20f);
        GUILayout.Label("Custom Editor Elements", EditorStyles.boldLabel);

        GUILayout.Space(10f);
        GUILayout.Label("Player Preferences");

        GUILayout.BeginHorizontal();
            GUILayout.Label("Player Name", GUILayout.Width(LabelWidth));
            GUILayout.TextField("Player 1");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.Label("Player Level", GUILayout.Width(LabelWidth));
            GUILayout.TextField("1");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.Label("Player Elo", GUILayout.Width(LabelWidth));
            GUILayout.TextField("100");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.Label("Player Score", GUILayout.Width(LabelWidth));
            GUILayout.TextField("100");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

            if(GUILayout.Button("Save"))
            {
                Debug.Log("PlayerPrefs Save");
            }

            if (GUILayout.Button("Reset"))
            {
                Debug.Log("PlayerPrefs DeleteAll");
            }

        GUILayout.EndHorizontal();

        // Thumbnails - Images with Buttons

        GUILayout.Space(20f);
        GUILayout.Label("Spawn Tank");
        GUILayout.BeginHorizontal();

        if (GUILayout.Button( tank.Tank_Red, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.CreateTank("Red");
        }

        if (GUILayout.Button(tank.Tank_Blue, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.CreateTank("Blue");
        }

        if (GUILayout.Button(tank.Tank_Black, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.CreateTank("Black");
        }



        GUILayout.EndHorizontal();




    }
}
