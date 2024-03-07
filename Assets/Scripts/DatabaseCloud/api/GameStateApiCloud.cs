public static class GameStateApiCloud
{

    private static readonly string url = DbConnectionCloud.base_url + "gameState";

    public static bool save(GameStateDto gameStateDto)
    {
        GameStateDto response = DbConnectionCloud.HttPost<GameStateDto>(url, gameStateDto);
        return response != null;
    }
}