using System.Collections.Generic;

public static class GameStateLocal
{

    public static bool Save(GameStateModel gameStateModel)
    {
        string sql = "INSERT INTO game_state ('id_user', 'id_avatar', 'id_level_challenge_description') VALUES " +
            "('" + gameStateModel.id_user + "', " + gameStateModel.id_avatar + ", '" + gameStateModel.id_level_challenge_description + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<GameStateModel> FindAll()
    {
        string sql = "SELECT * FROM game_state";
        return DbConnectionLocal.Read<List<GameStateModel>>(sql);
    }

}
