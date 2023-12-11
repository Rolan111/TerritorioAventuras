using System;
using System.Net;
using System.IO;

public static class ConnectionAPI {

    private static readonly string base_url = "http://localhost:8080/";

    public static class User {

        private static readonly string url = base_url + "User/";

        public static bool login(string user, string pass)
        {
            string completeUrl = String.Format(url + "findByUserAndPassword?user={0}&password={1}", user, pass);
            string response = ConnectionAPI.HttpQuery(completeUrl);
            return response != "";
        }
    }
	

    private static string HttpQuery(string completeUrl)
    {
        var request = (HttpWebRequest)WebRequest.CreateHttp(completeUrl);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        return jsonResponse;
    }
}