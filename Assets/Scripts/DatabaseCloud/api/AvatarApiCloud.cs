using System.Collections.Generic;

public static class AvatarApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "avatar";

    public static bool findAll()
    {
        List<AvatarDto> response = DbConnectionCloud.HttpGet<List<AvatarDto>>(url + "/findAll");
        return response != null;
    }

    public static bool save(AvatarDto avatarDto)
    {
        AvatarDto response = DbConnectionCloud.HttPost<AvatarDto>(url, avatarDto);
        return response != null;
    }
}