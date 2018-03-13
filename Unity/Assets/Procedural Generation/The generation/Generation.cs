using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(mapgenerator))]

public class Generation : Editor {
    public override void OnInspectorGUI()
    {
        mapgenerator map = (mapgenerator) target;
        DrawDefaultInspector();
        if (GUILayout.Button("Generation"))
        {
            map.gennmap();
        }

        base.OnInspectorGUI();
    }

}
