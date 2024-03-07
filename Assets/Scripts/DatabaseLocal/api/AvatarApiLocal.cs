using System.Collections.Generic;


public static class AvatarApiLocal
{
    public static bool save()
    {
        string sql = "INSERT INTO avatar ('avatar', 'id_gender', 'register_date') VALUES ('PRUEBAS', 2, '2023-10-05 20:20:45');";
        DbConnectionLocal.Write<AvatarModel>(sql);
        return true;
    }

    public static List<AvatarModel> findAll()
    {
        string sql = "SELECT * FROM avatar";
        return DbConnectionLocal.Read<List<AvatarModel>>(sql);
    }
}
