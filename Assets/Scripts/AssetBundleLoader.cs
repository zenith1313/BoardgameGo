using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var dir = Application.streamingAssetsPath;
        AssetBundle bundle = AssetBundle.LoadFromFile(dir);
        bundle.LoadAssetAsync<GameObject>("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
