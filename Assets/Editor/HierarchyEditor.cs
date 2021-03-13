using UnityEditor;

public class HierarchyEditor : EditorWindow
{
    [MenuItem("Tools/Hierarchy Editor")]
    public static void ShowWindow()
    {
        GetWindow<HierarchyEditor>("HierarchyEditor");
    }

    private void OnGUI()
    {
        CustomHierarchy.gameObjectFontColor = EditorGUILayout.ColorField("Original Font Color",
            CustomHierarchy.gameObjectFontColor);

        CustomHierarchy.prefabOrgFontColor = EditorGUILayout.ColorField("Prefab Original Font Color",
            CustomHierarchy.prefabOrgFontColor);

        CustomHierarchy.prefabModFontColor = EditorGUILayout.ColorField("Prefab Modified Font Color",
            CustomHierarchy.prefabModFontColor);

        CustomHierarchy.inActiveColor = EditorGUILayout.ColorField("Inactive Color",
            CustomHierarchy.inActiveColor);
    }
}
