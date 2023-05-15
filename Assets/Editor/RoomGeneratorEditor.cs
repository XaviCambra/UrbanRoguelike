using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomGenerator))]
public class RoomGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoomGenerator m_RoomGenerator = (RoomGenerator)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Generate Room Testing Button"))
        {
            //m_RoomGenerator.GenerateRandomScene();
        }
    }
}
