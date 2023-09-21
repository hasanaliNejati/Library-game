using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "saveObejects", menuName = "ScriptableObjects/saveTool", order = 0)]
public class SaveSO : ScriptableObject
{
    [SerializeField] List<ScriptableObject> objects;

    [ContextMenu("Save")]
    public void Save()
    {
        foreach (var obj in objects)
        {
            EditorUtility.SetDirty(obj);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("save : " + obj.name);
        }
    }

}
