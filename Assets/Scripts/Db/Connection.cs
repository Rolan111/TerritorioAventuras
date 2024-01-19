using System.Net;
using System.IO;
using UnityEngine;
using System.Text;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using System;

public static class Connection {

    public static readonly string base_url = "http://localhost:8080/";

    public static T HttPost<T>(string completeUrl, T dto)
    {
        return Http<T>(completeUrl, JsonUtility.ToJson(dto), "POST");
    }

    public static T HttpGet<T>(string completeUrl)
    {
        return Http<T>(completeUrl, "", "GET");
    }

    public static string buildUrl<T>(T dto)
    {
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

        var element = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonUtility.ToJson(dto));
        foreach (var item in element)
        {
            var value = item.Value.ToString();

            if (!value.Equals("") || !value.Equals("0"))
            {
                queryString.Add(item.Key, value);
            }
        }
        return "?" + queryString.ToString();
    }

    private static T Http<T>(string completeUrl, string dataJson, string method)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
        request.Method = method;

        Debug.Log(completeUrl);
        Debug.Log(dataJson);

        if (method == "POST")
        {
            byte[] data = Encoding.ASCII.GetBytes(dataJson);

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
        }

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
}