using UnityEditor;
using UnityEngine;

public class ScriptFromTemplateCreator : MonoBehaviour
{
    private const string pathToTemplate_Item = "Assets/Scripts/ScriptFromTemplate/Templates/ItemTemplate.txt";

    [MenuItem(itemName: "Assets/Create/Item/Item Effect Script", isValidateFunction: false, priority = 1)]
    public static void CreateScriptFromTemplate_00()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToTemplate_Item, "new Item.cs");
    }
}