using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player_BLACKBOARD))]
public class Player_BLACKBOARDEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Player_BLACKBOARD l_Blackboard = (Player_BLACKBOARD)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Get Buff"))
        {
            l_Blackboard.TEST_GetBuff();
        }
    }
}
