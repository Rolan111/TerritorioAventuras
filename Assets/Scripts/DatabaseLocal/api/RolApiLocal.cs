using System.Collections.Generic;

public static class RolApiLocal
{

    public static readonly int ROL_ESTUDIANTE = 1;
    public static readonly int ROL_DOCENTE = 2;
    public static readonly int ROL_ADMIN = 3;

    public static int Save(RolModel rolModel)
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
