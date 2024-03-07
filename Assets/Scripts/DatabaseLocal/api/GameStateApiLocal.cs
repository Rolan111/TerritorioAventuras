public static class GameStateLocal
{

    public static GameStateModel findAll()
    {
        string sql = "SELECT * FROM gameState";
        return DbConnectionLocal.Read<GameStateModel>(sql);
    }

}
