using UnityEditor;
using UnityEngine;
using System.IO;

public class NamespaceChecker : AssetPostprocessor
{
    static void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (var asset in importedAssets)
        {
            if (asset.EndsWith(".cs"))
            {
                var text = File.ReadAllText(asset);
                if (!text.Contains("namespace "))
                {
                    Debug.LogError($"File {asset} has no namespace!");
                }
            }
        }
    }
}