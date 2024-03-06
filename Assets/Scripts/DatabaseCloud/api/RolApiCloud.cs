public static class RolApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "rol";

    public static bool save(RolDto rolDto)
    {
        RolDto response = DbConnectionCloud.HttPost<RolDto>(url, rolDto);
        return response != null;
    }
}