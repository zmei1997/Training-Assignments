using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Model;

namespace Data.Repository
{
    public class CountryRepository : IRepository<Countries>
    {
        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from Countries where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public IEnumerable<Countries> GetAll()
        {
            throw new NotImplementedException();
        }

        public Countries GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from Countries where name = @name";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }
            sqlConnection.Close();
            return id;
        }

        public int Insert(Countries obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Countries obj)
        {
            throw new NotImplementedException();
        }
    }
}
