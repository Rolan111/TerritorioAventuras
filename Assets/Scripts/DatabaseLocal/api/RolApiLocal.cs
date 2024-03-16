using System.Collections.Generic;

public static class RolApiLocal
{

    public static bool Save(RolModel rolModel)
    {
        string sql = "INSERT INTO rol ('rol') VALUES ('" + rolModel.rol + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<RolModel> FindAll()
    {
        string sql = "SELECT * FROM rol";
        return DbConnectionLocal.Read<List<RolModel>>(sql);
    }

}
