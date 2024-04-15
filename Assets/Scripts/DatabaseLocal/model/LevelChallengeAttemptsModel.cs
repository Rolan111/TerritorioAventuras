using System;

[Serializable]
public class LevelChallengeAttemptsModel : BaseModel
{

    public int id_challenge_description { get; set; }

    public string attempts { get; set; }

    public string game_time { get; set; }

}

