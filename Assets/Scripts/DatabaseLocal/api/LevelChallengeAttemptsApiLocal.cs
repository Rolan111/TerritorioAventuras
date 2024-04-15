using System.Collections.Generic;

public static class LevelChallengeAttemptsApiLocal
{

    public static bool Save(LevelChallengeAttemptsModel levelChallengeAttemptsModel)
    {
        string sql = "INSERT INTO level_challenge_attempt ('id_challenge_description','attempts','game_time') VALUES " +
            "('" + levelChallengeAttemptsModel.id_challenge_description + "','" + levelChallengeAttemptsModel.attempts + "'," +
            "'" + levelChallengeAttemptsModel.game_time + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<LevelChallengeAttemptsModel> FindAll()
    {
        string sql = "SELECT * FROM level_challenge_attempt";
        return DbConnectionLocal.Read<List<LevelChallengeAttemptsModel>>(sql);
    }

}
