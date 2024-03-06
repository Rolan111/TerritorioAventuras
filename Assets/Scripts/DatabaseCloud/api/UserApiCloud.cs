public static class UserApiCloud {

    private static readonly string url = DbConnectionCloud.base_url + "user";

    private static UserDto user;

    public static bool login(UserDto userDto)
    {
        string data = DbConnectionCloud.buildUrl(userDto);

        UserDto response = DbConnectionCloud.HttpGet<UserDto>(url + "/login" + data);

        if (response != null)
        {
            UserApiCloud.user = response;
        }

        return response != null;
    }

    public static bool save(UserDto userDto)
    {
        UserDto response = DbConnectionCloud.HttPost<UserDto>(url, userDto);
        return response != null;
    }

    public static UserDto getUser()
    {
        return user;
    }
}