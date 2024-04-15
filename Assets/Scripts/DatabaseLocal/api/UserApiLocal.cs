using System.Collections.Generic;

public static class UserApiLocal
{

    public static bool Save(UserModel userModel)
    {
        string sql = "INSERT INTO user ('name', 'age', 'email', 'school', 'user', 'password', 'id_gender', 'id_rol') VALUES " +
            "('" + userModel.name + "','" + userModel.age + "','" + userModel.email + "','" + userModel.school + "'," +
            "'" + userModel.user + "','" + userModel.password + "','" + userModel.id_gender + "','" + userModel.id_rol + "')";
        return DbConnectionLocal.Write(sql);
    }

    public static List<UserModel> FindAll()
    {
        string sql = "SELECT * FROM user";
        return DbConnectionLocal.Read<List<UserModel>>(sql);
    }
    
    public static UserModel FindByUserAndPassword(string user, string password)
    {
        string sql = "SELECT * FROM user WHERE user='" + user + "' and password='" + password + "'";
        return DbConnectionLocal.Read<UserModel>(sql);
    }

}
