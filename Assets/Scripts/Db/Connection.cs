using System.Net;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

public static class Connection {

    public static readonly string base_url = "http://localhost:8080/";

    public static T HttPost<T>(string completeUrl, T data)
    {
        return Http<T>(completeUrl, data, "POST");
    }

    public static T HttpGet<T>(string completeUrl)
    {
        return Http<T>(completeUrl, default, "GET");
    }

    private static T Http<T>(string completeUrl, T data, string method)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
        request.Method = method;

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        if (jsonResponse == null || jsonResponse.Length <= 0)
        {
            return default;
        }
        else
        {
            return JsonUtility.FromJson<T>(jsonResponse);
        }
    }

    private static T zxczxczxczxc<T>()
    {
        WWWForm wWWForm = new WWWForm();
        wWWForm.AddField("", "");

        UnityWebRequest request = UnityWebRequest.Post("", wWWForm);

        request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            return JsonUtility.FromJson<T>(request.downloadHandler.text);
        }
        else
        {
            return default;
        }
    }
}