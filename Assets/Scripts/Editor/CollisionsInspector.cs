using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(CollisionsFinal))]
public class CollisionsInspector : Editor
{

    static bool stateFoldout;
    static bool drawDefaultInspector;

    public override void OnInspectorGUI()
    {
       // EditorGUILayout.BeginVertical(EditorStyles.textArea);
        CollisionsFinal col = (CollisionsFinal)target;
        GUIStyle booleanText = new GUIStyle();

        EditorGUILayout.Space();
        EditorGUI.indentLevel = 1;

        stateFoldout = EditorGUILayout.Foldout(stateFoldout, "State", true, EditorStyles.toolbarDropDown);
        if(stateFoldout)
        {
            EditorGUILayout.BeginVertical();

            EditorGUI.indentLevel = 3;

            if(col.isGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Grounded", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justGotGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("just Got Grounded", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justNotGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("just Not Grounded", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.isFalling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Falling", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.isCeiling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Ceiling", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.wasCeilingLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("wasCeilingLastFrame", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justGotCeiling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("justGotCeiling", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justNotCeiling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("justNotCeiling", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.isTouchingWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("isTouchingWall", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.wasTouchingWallLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("wasTouchingWallLastFrame", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justGotTouchingWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("justGotTouchingWall", booleanText);

            EditorGUI.indentLevel = 3;
            if(col.justNotTouchingWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("justNotTouchingWall", booleanText);















            EditorGUILayout.EndVertical();
        }


        EditorGUILayout.Space();
        EditorGUI.indentLevel = 1;

        drawDefaultInspector = EditorGUILayout.Foldout(drawDefaultInspector, "Default Inspector", true, EditorStyles.toolbarDropDown);
        if(drawDefaultInspector)
        {
            EditorGUI.indentLevel = 2;
            base.OnInspectorGUI();
        }





        /*
        col.wasGroundedLastFrame = EditorGUILayout.Toggle("was Grounded Last Frame", col.wasGroundedLastFrame);
        col.justGotGrounded = EditorGUILayout.Toggle("just Got Grounded", col.justGotGrounded);
        col.justNotGrounded = EditorGUILayout.Toggle("just Not Grounded", col.justNotGrounded);
        */
    }
}
