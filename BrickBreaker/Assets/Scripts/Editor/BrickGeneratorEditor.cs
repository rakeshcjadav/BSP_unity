using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BrickGenerator))]
public class BrickGeneratorEditor : Editor
{
    SerializedProperty BrickScale;
    SerializedProperty startPos;
    SerializedProperty endPos;
    BrickGenerator brickGenerator;

    private void OnEnable()
    {
        BrickScale = serializedObject.FindProperty("BrickScale");
        startPos = serializedObject.FindProperty("startPos");
        endPos = serializedObject.FindProperty("endPos");

        brickGenerator = (BrickGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Brick Grid Generator");

        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generator"))
        {
            brickGenerator.Clear();
            brickGenerator.GenerateGrid();
        }

        if(GUILayout.Button("Clear"))
        {
            brickGenerator.Clear();
        }

        GUILayout.EndHorizontal();
    }
}
