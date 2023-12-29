using System.Collections.Generic;

public static class EmoticonApi
{

    private static readonly string url = Connection.base_url + "emoticon/";

    public static bool findAll()
    {
        List<EmoticonDto> response = Connection.HttpGet<List<EmoticonDto>>(url + "findAll");
        return response != null;
    }

    public static bool save(EmoticonDto emoticonDto)
    {
        EmoticonDto response = Connection.HttPost<EmoticonDto>(url, emoticonDto);
        return response != null;
    }
}