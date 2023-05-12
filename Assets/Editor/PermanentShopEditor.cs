using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PermanentShop))]
public class PermanentShopEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PermanentShop l_Shop = (PermanentShop)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Renew Shop"))
        {
            l_Shop.RandomPowerUps(l_Shop.m_NotPickedPowerUps);
        }
    }
}
