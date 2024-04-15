using System.Collections.Generic;

public static class GenderApiLocal
{

    public static bool Save(GenderModel genderModel)
    {
        string sql = "INSERT INTO gender ('gender') VALUES ('" + genderModel.gender + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<GenderModel> FindAll()
    {
        string sql = "SELECT * FROM gender";
        return DbConnectionLocal.Read<List<GenderModel>>(sql);
    }

}
