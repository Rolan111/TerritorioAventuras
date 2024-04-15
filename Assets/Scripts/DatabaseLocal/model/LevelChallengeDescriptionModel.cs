using System;

[Serializable]
public class LevelChallengeDescriptionModel : BaseModel
{

    public string name_level { get; set; }

    public string name_badge { get; set; }

    public string coins { get; set; }

    public int id_emoticon { get; set; }

}