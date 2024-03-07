using System.Collections.Generic;

public static class EmoticonApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "emoticon";

    public static bool findAll()
    {
        List<EmoticonDto> response = DbConnectionCloud.HttpGet<List<EmoticonDto>>(url + "/findAll");
        return response != null;
    }

    public static bool save(EmoticonDto emoticonDto)
    {
        EmoticonDto response = DbConnectionCloud.HttPost<EmoticonDto>(url, emoticonDto);
        return response != null;
    }
}