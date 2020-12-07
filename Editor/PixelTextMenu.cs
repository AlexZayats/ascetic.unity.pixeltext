using UnityEditor;
using UnityEngine;

namespace Ascetic.Unity.PixelText.Editor
{
public class PixelTextMenu : MonoBehaviour
{
    [MenuItem("GameObject/3D Object/Pixel Text")]
    static void CreatePixelTextGameObject(MenuCommand menuCommand)
    {
        var go = new GameObject("Pixel Text");
        var pt = go.AddComponent<PixelTextRenderer>();
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
}
