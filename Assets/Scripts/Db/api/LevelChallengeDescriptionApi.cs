public static class LevelChallengeDescriptionApi
{

    private static readonly string url = Connection.base_url + "levelChallengeDescription";

    public static bool save(LevelChallengeDescriptionDto levelChallengeDescriptionDto)
    {
        LevelChallengeDescriptionDto response = Connection.HttPost<LevelChallengeDescriptionDto>(url, levelChallengeDescriptionDto);
        return response != null;
    }
}