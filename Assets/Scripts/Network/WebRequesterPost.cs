using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequesterPost : MonoBehaviour
{
    public string Url;
    
    [TextArea]
    public string PostData;
    
    public delegate void WebReponseSuccess(string s);
    public delegate void WebReponseError(string s);
    
    // Start is called before the first frame update
    private void Awake()
    {
        SendReq();
    }
    
    public void SendReq()
    {
        StartCoroutine(SendPostRequest());
    }
    
    public IEnumerator SendPostRequest()
    {
        var webRequest = UnityWebRequest.Post(Url, PostData);

        yield return webRequest.SendWebRequest();

        var pages = Url.Split("/");
        var page = pages.Length - 1;

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Success");
        }
        else if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error " + webRequest.error);
        }
        else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error " + webRequest.error);
        }
        else if (webRequest.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.Log("Error " + webRequest.error);
        }
    }
}
