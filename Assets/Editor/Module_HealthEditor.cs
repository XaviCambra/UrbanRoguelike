using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Module_Health))]
public class Module_HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Module_Health m_ModuleHealth = (Module_Health)target;
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
