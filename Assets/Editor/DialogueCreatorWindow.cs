using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Codice.Client.Common.Connection.ServerAlias;
using UnityEngine.Events;

public class DialogueCreatorWindow : EditorWindow
{
    public string speakerName = "Player"; //default values
    public string[] messages;
    //determine how to trigger this dialogue popup (perhaps attach a trigger?)
    public Sprite speakerImage;



    [MenuItem("Tools/Dialogue Creator Window")]
    public static void ShowWindow()
    {
        DialogueCreatorWindow wnd = GetWindow<DialogueCreatorWindow>();
        wnd.titleContent = new GUIContent("Dialogue Creator");
    }

    public void OnGUI()
    {
        VisualElement root = rootVisualElement; //root VisualElement object

        GUILayout.Label("Create a Dialogue", EditorStyles.boldLabel);

        speakerName = EditorGUILayout.TextField("Speaker Name", speakerName);
        
        //exposing data objects to the editor window
        ScriptableObject scriptableObj = this;
        SerializedObject serializedObject = new SerializedObject(scriptableObj);
        SerializedProperty serialProp = serializedObject.FindProperty("messages");
        

        //TODO: make the trigger the NPC's task or quest complete or put it in some dialogue system queue to be triggered/popped up
        SerializedProperty img = serializedObject.FindProperty("speakerImage");

        EditorGUILayout.PropertyField(serialProp, true);
        EditorGUILayout.PropertyField(img, false);

        serializedObject.ApplyModifiedProperties(); //makes array modifiable in the editor window

        EditorGUILayout.Space(); //add a space

        if (GUILayout.Button("Preview Dialogue"))
        {
            //display sample of the Dialogue UI on the screen using the provided or default dialogue UI 
            //make sure the dialogue UI is enabled
        }

        if (GUILayout.Button("Add to NPC"))
        {
            //adds it as a data object to the NPC's dialogue queue(?)
            //doesn't need to be a specific queue order
        }
    }
}
