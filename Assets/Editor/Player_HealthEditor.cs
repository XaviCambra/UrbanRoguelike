using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Player_Health))]
public class Player_HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Player_Health m_ModuleHealth = (Player_Health)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Take Damage Testing Button"))
        {
            m_ModuleHealth.TakeDamage(10);
        }
        if (GUILayout.Button("Reset Health"))
        {
            m_ModuleHealth.ResetObject();
        }
    }
}
