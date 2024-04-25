using System;

[Serializable]
public class GameStateModel : BaseModel
{

    public int id_user { get; set; }

    public int id_avatar { get; set; }

    public int id_level_description { get; set; }

    public string attempts { get; set; }

    public string coins { get; set; }

    public string game_time { get; set; }

    public int tools { get; set; }

    public int actual_game { get; set; }

}

