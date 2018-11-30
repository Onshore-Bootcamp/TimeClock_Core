using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TimeClock_Core_DAL.Mapping;
using TimeClock_Core_DAL.Models;

namespace TimeClock_Core_DAL
{
    public class UserDAO
    {
        private readonly string _ConnectionString;
        public UserDAO(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        //Done
        public List<UserDO> ViewUsers()
        {
            List<UserDO> allUsers = new List<UserDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                using (SqlCommand command = new SqlCommand("User_VIEW_USERS", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDO row = new UserDO();
                            row.Id = reader.GetInt64(0);
                            row.LMSId = reader.GetInt64(1);
                            row.Username = reader.GetString(2);
                            row.FirstName = reader.GetString(3);
                            row.LastName = reader.GetString(4);
                            row.Password = reader.GetString(5);
                            row.Role = reader.GetString(6);
                            row.Active = reader.GetBoolean(7);

                            row.GroupId = reader.GetInt64(8);
                            row.CourseId = reader.GetInt64(9);
                            allUsers.Add(row);
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            return allUsers;
        }

        //Done
        public UserDO ViewUserByUsername(string username)
        {
            UserDO oUser = new UserDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                using (SqlCommand command = new SqlCommand("User_VIEW_BY_USERNAME", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oUser = UserMapper.MapReaderToSingle(reader);
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            return oUser;
        }

        //Done
        public UserDO ViewUserByUserId(Int64 userId)
        {
            UserDO oUser = new UserDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                using (SqlCommand command = new SqlCommand("User_VIEW_BY_USER_ID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oUser = UserMapper.MapReaderToSingle(reader);
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            return oUser;
        }

        //Done
        public void CreateUser(UserDO userDO)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                using (SqlCommand command = new SqlCommand("User_CREATE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LMSId", userDO.LMSId);
                    command.Parameters.AddWithValue("@Username", userDO.Username);
                    command.Parameters.AddWithValue("@FirstName", userDO.FirstName);
                    command.Parameters.AddWithValue("@LastName", userDO.LastName);
                    command.Parameters.AddWithValue("@Password", userDO.Password);
                    command.Parameters.AddWithValue("@Role", userDO.Role);
                    command.Parameters.AddWithValue("@Active", userDO.Active);

                    command.Parameters.AddWithValue("@GroupId", userDO.GroupId);
                    command.Parameters.AddWithValue("@CourseId", userDO.CourseId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }
        
        public void UpdateUser(UserDO userDO)
        {
            throw new NotImplementedException();
        }
    }
}
