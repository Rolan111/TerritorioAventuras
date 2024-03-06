public static class GenderApi
{

    private static readonly string url = Connection.base_url + "gender";

    public static bool save(GenderDto genderDto)
    {
        GenderDto response = Connection.HttPost<GenderDto>(url, genderDto);
        return response != null;
    }
}