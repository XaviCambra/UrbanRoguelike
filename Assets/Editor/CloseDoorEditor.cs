using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CloseDoor))]
public class CloseDoorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CloseDoor m_CloseDoor = (CloseDoor)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Apply Effect"))
        {
            m_CloseDoor.ApplyEffectItem();
        }
    }
}
