public static class UserApiLocal
{
    
    public static UserModel login(string user, string password)
    {
        string sql = "SELECT * FROM user WHERE user='" + user + "' and password='" + password + "'";
        return DbConnectionLocal.Read<UserModel>(sql);
    }

}
