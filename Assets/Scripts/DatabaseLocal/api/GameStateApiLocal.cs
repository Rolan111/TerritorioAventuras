using System.Collections.Generic;

public static class GameStateApiLocal
{

    public static int Save(GameStateModel gameStateModel)
    {
        string sql = "INSERT INTO game_state ('id_user', 'id_avatar', 'id_level_description', 'attempts', 'coins', 'game_time', 'tools', 'actual_game') VALUES " +
            "('" + gameStateModel.id_user + "','" + gameStateModel.id_avatar + "','" + gameStateModel.id_level_description + "','" +
            gameStateModel.attempts + "','" + gameStateModel.coins + "','" + gameStateModel.game_time + "','" + gameStateModel.tools + "', '1')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<GameStateModel> FindAll()
    {
        string sql = "SELECT * FROM game_state";
        return DbConnectionLocal.Read<List<GameStateModel>>(sql);
    }

    public static GameStateModel FindActualGameByIdUser(int id_user)
    {
        string sql = "SELECT * FROM game_state WHERE id_user = '" + id_user + "' AND actual_game = '1'";
        return DbConnectionLocal.Find<GameStateModel>(sql);
    }

    public static List<GameStateModel> FindByIdUser(int id_user)
    {
        string sql = "SELECT * FROM game_state WHERE id_user = '" + id_user + "'";
        return DbConnectionLocal.Read<List<GameStateModel>>(sql);
    }

    public static int UpdateActualGameByIdUser(int id_user)
    {
        string sql = "UPDATE game_state SET actual_game = '0' WHERE id_user = '" + id_user + "'";
        return DbConnectionLocal.Write(sql);
    }
}
