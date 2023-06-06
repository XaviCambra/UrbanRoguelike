using UnityEditor;
using UnityEngine;

public class ScriptFromTemplateCreator : MonoBehaviour
{
    private const string pathToTemplate_Item = "Assets/Scripts/ScriptFromTemplate/Templates/ItemTemplate.txt";
    private const string pathToTemplate_PowerUp = "Assets/Scripts/ScriptFromTemplate/Templates/PowerUp_Template.txt";

    [MenuItem(itemName: "Assets/Create/Item/Item Effect Script", isValidateFunction: false, priority = 1)]
    public static void CreateScriptFromTemplate_00()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToTemplate_Item, "new Item.cs");
    }


    [MenuItem(itemName: "Assets/Create/Power Up/Power Up Script", isValidateFunction: false, priority = 2)]
    public static void CreateScriptFromTemplate_01()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToTemplate_PowerUp, "new Item.cs");
    }

}