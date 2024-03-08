using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AvatarApiLocal
{

    public static bool Save(AvatarModel avatarModel)
    {
        string sql = "INSERT INTO avatar ('avatar', 'id_gender') VALUES ('" + avatarModel.avatar + "', " + avatarModel.id_gender + ")";
        return DbConnectionLocal.Write(sql);
    }

    public static List<AvatarModel> FindAll()
    {
        string sql = "SELECT * FROM avatar";
        return DbConnectionLocal.Read<List<AvatarModel>>(sql);
    }

    public static void CreateExcel()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/avatar.csv";

        TextWriter textWriter = new StreamWriter(path, false);
        textWriter.WriteLine("id, avatar, id_gender, register_date");
        textWriter.Close();

        textWriter = new StreamWriter(path, true);

        FindAll().ForEach(avatarModel => {
            textWriter.WriteLine(avatarModel.id + "," + avatarModel.avatar + "," + avatarModel.id_gender + "," + avatarModel.register_date);
        });

        textWriter.Close();
    }
}
