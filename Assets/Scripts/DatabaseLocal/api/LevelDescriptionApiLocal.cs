using System.Collections.Generic;

public static class LevelDescriptionApiLocal
{

    public static int Save(LevelDescriptionModel levelChallengeDescriptionModel)
    {
        string sql = "INSERT INTO level_description ('name_level', 'name_badge', 'coins', 'scene_name') " +
            "VALUES ('" + levelChallengeDescriptionModel.name_level + "', '" + levelChallengeDescriptionModel.name_badge + "', " +
            "'" + levelChallengeDescriptionModel.coins + "', '" + levelChallengeDescriptionModel.scene_name + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<LevelDescriptionModel> FindAll()
    {
        string sql = "SELECT * FROM level_description";
        return DbConnectionLocal.Read<List<LevelDescriptionModel>>(sql);
    }

    public static LevelDescriptionModel FindBySceneName(string scene_name)
    {
        string sql = "SELECT * FROM level_description WHERE scene_name = '" + scene_name + "'";
        return DbConnectionLocal.Find<LevelDescriptionModel>(sql);
    }

    public static LevelDescriptionModel FindById(int id)
    {
        string sql = "SELECT * FROM level_description WHERE id = '" + id + "'";
        return DbConnectionLocal.Find<LevelDescriptionModel>(sql);
    }

}
