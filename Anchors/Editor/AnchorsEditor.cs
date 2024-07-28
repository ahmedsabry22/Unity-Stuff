

// This script was create by Ahmed Sabry
// for contact: ahmedsabry19@outlook.com
// Linkedin: https://www.linkedin.com/in/ahmed-sabry19
// Youtube: https://www.youtube.com/ahmedsabrygamedev
// My regards


using UnityEngine;
using UnityEditor;

public class AnchorsEditor : EditorWindow
{
    private void OnGUI()
    {
    }

    [MenuItem("Anchors/Set Anchors To Fit Rect %#q", priority = 1)]
    public static void SetAnchorsToFitRect_Shortcut()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (var g in selectedGameObjects)
        {
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                Undo.RecordObject(rectTransform, "Set Anchors");
                Anchors.SetAnchorsToRect(rectTransform);
            }
        }
    }
}