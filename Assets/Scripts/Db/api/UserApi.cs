public static class UserApi{

    private static readonly string url = Connection.base_url + "user/";

    private static UserDto user;

    public static bool login(UserDto userDto)
    {
        string data = Connection.buildUrl(userDto);

        UserDto response = Connection.HttpGet<UserDto>(url + "login" + data);

        if (response != null)
        {
            UserApi.user = response;
        }

        return response != null;
    }

    public static bool save(UserDto userDto)
    {
        UserDto response = Connection.HttPost<UserDto>(url, userDto);
        return response != null;
    }

    public static UserDto getUser()
    {
        return user;
    }
}