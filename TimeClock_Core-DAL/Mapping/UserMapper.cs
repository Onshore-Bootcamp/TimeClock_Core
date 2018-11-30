namespace TimeClock_Core_DAL.Mapping
{
    using System.Data.SqlClient;
    using TimeClock_Core_DAL.Models;

    public static class UserMapper
    {
        public static UserDO MapReaderToSingle(SqlDataReader reader)
        {
            UserDO oUser = new UserDO();
            oUser.Id = reader.GetInt64(0);
            oUser.LMSId = reader.GetInt64(1);
            oUser.Username = reader.GetString(2);
            oUser.FirstName = reader.GetString(3);
            oUser.LastName = reader.GetString(4);
            oUser.Password = reader.GetString(5);
            oUser.Role = reader.GetString(6);
            oUser.Active = reader.GetBoolean(7);

            oUser.GroupId = reader.GetInt64(8);
            oUser.CourseId = reader.GetInt64(9);
            return oUser;
        }
    }
}
