using System;
using static UnityEditor.ShaderData;

public static class User{

    private static readonly string url = Connection.base_url + "user/";

    private static UserDto user;

    public static bool login(string user, string pass)
    {
        string completeUrl = String.Format(url + "findByUserAndPassword?user={0}&password={1}", user, pass);

        UserDto response = Connection.HttPost<UserDto>(completeUrl);

        if (response != null)
        {
            User.user = response;
        }

        return response != null;
    }

    public static bool register(UserDto user)
    {
        string completeUrl = String.Format(url + "save");

    }

    public static UserDto getUser()
    {
        return user;
    }
}