﻿using System.Data.SqlClient;

namespace CRUDMVC.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public UserDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }
        public int Register(User user)
        {
            string qry = "insert into Users values(@username, @email, @password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("username", user.UserName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Login(User user)
        {
            string qry="select * from Users where username=@username and password=@password"; 
            cmd = new SqlCommand(qry, con); 
            cmd.Parameters.AddWithValue("username", user.UserName);
            cmd.Parameters.AddWithValue("password", user.Password);
            con.Open();
            dr= cmd.ExecuteReader(); 
            bool result = dr.HasRows;
            con.Close();
            if (result)
            {
                return 1;
            }
            else
            {
                return 0;
            }






        }


    }
}
