using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Shop))]
public class ShopEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Shop l_Shop = (Shop)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Renew Shop"))
        {
            l_Shop.RandomPowerUps();
        }
    }
}
