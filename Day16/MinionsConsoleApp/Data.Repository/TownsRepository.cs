using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Model;

namespace Data.Repository
{
    public class TownsRepository : IRepository<Towns>
    {
        public List<String> UpperTownNamesByCountry(string countryName)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select upper(t.name) as townName from Towns t inner join Countries c on t.countryId = c.id where c.name = @countryName";
            cmd.Parameters.AddWithValue("@countryName", countryName);
            cmd.Connection = sqlConnection;
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> listOfName = new List<string>();
            while (reader.Read())
            {
                string townName = Convert.ToString(reader["townName"]);
                if (townName != null)
                {
                    listOfName.Add(townName);
                }
            }
            sqlConnection.Close();
            return listOfName;

        }

        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from Towns where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public IEnumerable<Towns> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from Towns where name = @name";
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

        public Towns GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name,CountryId from Towns where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            Towns t = new Towns();
            while (reader.Read())
            {
                string name = Convert.ToString(reader["name"]);
                int countryId = Convert.ToInt32(reader["CountryId"]);
                t.Name = name;
                t.CountryId = countryId;
            }
            sqlConnection.Close();
            return t;
        }

        public int Insert(Towns obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Towns values(@name, @CountryId)";
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public int Update(Towns obj)
        {
            throw new NotImplementedException();
        }
    }
}
