public static class GenderApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "gender";

    public static bool save(GenderDto genderDto)
    {
        GenderDto response = DbConnectionCloud.HttPost<GenderDto>(url, genderDto);
        return response != null;
    }
}