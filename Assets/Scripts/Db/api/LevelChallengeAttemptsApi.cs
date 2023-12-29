public static class LevelChallengeAttemptsApi
{

    private static readonly string url = Connection.base_url + "levelChallengeAttempts/";

    public static bool save(LevelChallengeAttemptsDto levelChallengeAttemptsDto)
    {
        LevelChallengeAttemptsDto response = Connection.HttPost<LevelChallengeAttemptsDto>(url, levelChallengeAttemptsDto);
        return response != null;
    }
}