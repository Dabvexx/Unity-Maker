using UnityEditor;
using UnityEngine;

//[InitializeOnLoad]
public class CustomHierarchy : MonoBehaviour
{
    private static Vector2 offset = new Vector2(0, 2);
    public static Color gameObjectFontColor = Color.black;
    public static Color prefabOrgFontColor = Color.black;
    public static Color prefabModFontColor = Color.white;
    public static Color inActiveColor = new Color(0.01f, 0.4f, 0.25f);

    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        /*Color fontColor = Color.black;
        Color backgroundColor = new Color(.76f, .76f, .76f);
        FontStyle styleFont = FontStyle.Normal;

        var obj = EditorUtility.InstanceIDToObject(instanceID);
        GameObject gameobj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (obj != null)
        {
            var prefabType = PrefabUtility.GetPrefabType(obj);

            if (gameobj.activeInHierarchy == false)
            {
                backgroundColor = inActiveColor;
            }

            if (prefabType == PrefabType.PrefabInstance)
            {
                styleFont = FontStyle.Bold;
                PropertyModification[] prefabMods = PrefabUtility.GetPropertyModifications(obj);

                foreach (PropertyModification prefabMod in prefabMods)
                {
                    if (prefabMod.propertyPath.ToString() != "m_Name" && prefabMod.propertyPath.ToString() != "m_LocalPosition.x" && prefabMod.propertyPath.ToString() != "m_LocalPosition.y" && prefabMod.propertyPath.ToString() != "m_LocalPosition.z" && prefabMod.propertyPath.ToString() != "m_LocalRotation.x" && prefabMod.propertyPath.ToString() != "m_LocalRotation.y" && prefabMod.propertyPath.ToString() != "m_LocalRotation.z" && prefabMod.propertyPath.ToString() != "m_LocalRotation.w" && prefabMod.propertyPath.ToString() != "m_RootOrder" && prefabMod.propertyPath.ToString() != "m_IsActive")
                    {
                        fontColor = prefabModFontColor;
                        break;
                    }
                }

                if (fontColor != prefabModFontColor) fontColor = prefabOrgFontColor;
            }

            Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);

            EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = fontColor },
                fontStyle = styleFont
            });
        } */


    } 
}
