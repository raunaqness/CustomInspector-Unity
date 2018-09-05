using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TankController))]
public class TankControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        TankController tank = (TankController)target;

        float ThumbnailWidth = 70;
        float ThumbnailHeight = 70;

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
        GUILayout.Label("Spawn Prop");
        GUILayout.BeginHorizontal();

        if (GUILayout.Button( tank.Thumbnail_Board, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.SpawnProp("board");
        }

        if (GUILayout.Button(tank.Thumbnail_OilDrum, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.SpawnProp("oil_drum");
        }

        if (GUILayout.Button(tank.Thumbnail_Crate, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.SpawnProp("crate");
        }

        //GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();

        if (GUILayout.Button(tank.Thumbnail_TrafficCone, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.SpawnProp("traffic_cone");
        }

        if (GUILayout.Button(tank.Thumbnail_Wheel, GUILayout.Width(ThumbnailWidth), GUILayout.Height(ThumbnailHeight)))
        {
            tank.SpawnProp("wheel");
        }

        GUILayout.EndHorizontal();




    }
}
