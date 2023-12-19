using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleCreate : MonoBehaviour
{
    [MenuItem("Bundle/Test")]
    public static void BuildAssetBundle()
    {
        var dir = "Assets/Prefabs/Cube.prefab";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}
