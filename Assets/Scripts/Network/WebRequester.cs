using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequester : MonoBehaviour
{
    public string Url;

    public ScriptableObject storage;

    public delegate void WebReponseSuccess(string s);
    public delegate void WebReponseError(string s);

    private void Awake()
    {
        SendReq();
    }

    public void SendReq()
    {
        StartCoroutine(SendRequest(RespSuccess));
    }

    public void RespSuccess(string msg)
    {
        var json = "{ \"alldata\" :" + msg + "}";
        Debug.Log("json : " + json);

        if (storage is UserData)
        {
            var data = JsonHelper.FromJson<User>(json);
            ((UserData) storage).alldata = data.ToList();
        }
        else if (storage is PostData)
        {
            var data = JsonHelper.FromJson<Post>(json);
            ((PostData) storage).alldata = data.ToList();
        }
    }
    
    public IEnumerator SendRequest(WebReponseSuccess text)
    {
        var webRequest = UnityWebRequest.Get(Url);

        yield return webRequest.SendWebRequest();

        var pages = Url.Split("/");
        var page = pages.Length - 1;

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            text?.Invoke(webRequest.downloadHandler.text);
        }
        else if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            
        }
        else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            
        }
        else if (webRequest.result == UnityWebRequest.Result.DataProcessingError)
        {
            
        }
    }
}
