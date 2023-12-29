public static class GameStateApi
{

    private static readonly string url = Connection.base_url + "gameState/";

    public static bool save(GameStateDto gameStateDto)
    {
        GameStateDto response = Connection.HttPost<GameStateDto>(url, gameStateDto);
        return response != null;
    }
}