public static class LevelChallengeDescriptionApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "levelChallengeDescription";

    public static bool save(LevelChallengeDescriptionDto levelChallengeDescriptionDto)
    {
        LevelChallengeDescriptionDto response = DbConnectionCloud.HttPost<LevelChallengeDescriptionDto>(url, levelChallengeDescriptionDto);
        return response != null;
    }
}