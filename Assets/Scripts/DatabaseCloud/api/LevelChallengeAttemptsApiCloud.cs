public static class LevelChallengeAttemptsApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "levelChallengeAttempts";

    public static bool save(LevelChallengeAttemptsDto levelChallengeAttemptsDto)
    {
        LevelChallengeAttemptsDto response = DbConnectionCloud.HttPost<LevelChallengeAttemptsDto>(url, levelChallengeAttemptsDto);
        return response != null;
    }
}