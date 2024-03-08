using System.Collections.Generic;

public static class EmoticonApiLocal
{

    public static bool Save(EmoticonModel emoticonModel)
    {
        string sql = "INSERT INTO emoticon ('emoticon') VALUES ('" + emoticonModel.emoticon + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<EmoticonModel> FindAll()
    {
        string sql = "SELECT * FROM emoticon";
        return DbConnectionLocal.Read<List<EmoticonModel>>(sql);
    }

}
