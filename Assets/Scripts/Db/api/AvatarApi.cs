using System.Collections.Generic;

public static class AvatarApi
{

    private static readonly string url = Connection.base_url + "avatar/";

    public static bool findAll()
    {
        List<AvatarDto> response = Connection.HttpGet<List<AvatarDto>>(url + "findAll");
        return response != null;
    }

    public static bool save(AvatarDto avatarDto)
    {
        AvatarDto response = Connection.HttPost<AvatarDto>(url, avatarDto);
        return response != null;
    }
}