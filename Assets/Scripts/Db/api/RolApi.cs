public static class RolApi
{

    private static readonly string url = Connection.base_url + "rol";

    public static bool save(RolDto rolDto)
    {
        RolDto response = Connection.HttPost<RolDto>(url, rolDto);
        return response != null;
    }
}