using System.Collections.Generic;

public static class LevelChallengeDescriptionApiLocal
{

    public static bool Save(LevelChallengeDescriptionModel levelChallengeDescriptionModel)
    {
        string sql = "INSERT INTO level_challenge_description ('name_level', 'name_badge', 'coins', 'id_emoticon') " +
            "VALUES ('" + levelChallengeDescriptionModel.name_level + "', '" + levelChallengeDescriptionModel.name_badge + "', " +
            "'" + levelChallengeDescriptionModel.coins + "', '" + levelChallengeDescriptionModel.id_emoticon + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<LevelChallengeDescriptionModel> FindAll()
    {
        string sql = "SELECT * FROM level_challenge_description";
        return DbConnectionLocal.Read<List<LevelChallengeDescriptionModel>>(sql);
    }

}
