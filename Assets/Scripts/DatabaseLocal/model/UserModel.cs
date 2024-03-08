using System;

[Serializable]
public class UserModel : BaseModel {

    public string name { get; set; }

    public string age { get; set; }

    public string email { get; set; }

    public string school { get; set; }

    public string user { get; set; }

    public string password { get; set; }

    public int id_gender { get; set; }

    public int id_rol { get; set; } 

}
