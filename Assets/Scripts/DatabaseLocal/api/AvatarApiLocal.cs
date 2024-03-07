using System.Collections.Generic;

public static class AvatarApiLocal
{
    public static bool save()
    {
        AvatarModel avatarModel = new AvatarModel();
        avatarModel.avatar = "PRUEBAS";
        avatarModel.id_gender = 2;

        string sql = "INSERT INTO avatar ('avatar', 'id_gender') VALUES ('" + avatarModel.avatar + "', " + avatarModel.id_gender + ")";
        DbConnectionLocal.Write<AvatarModel>(sql);
        return true;
    }

    public static List<AvatarModel> findAll()
    {
        string sql = "SELECT * FROM avatar";
        return DbConnectionLocal.Read<List<AvatarModel>>(sql);
    }

}
