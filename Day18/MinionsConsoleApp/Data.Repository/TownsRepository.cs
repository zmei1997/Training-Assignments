using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Model;

namespace Data.Repository
{
    public class TownsRepository : IRepository<Towns>
    {
        DbHelper helper;
        public TownsRepository()
        {
            helper = new DbHelper();
        }

        public Towns GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select name,CountryId from Towns where Id = @Id";
                return connection.QueryFirstOrDefault<Towns>(str, new { Id = id });
            }
        }

        public int Insert(Towns obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "insert into Towns values(@name, @CountryId)";
                return connection.Execute(str, obj);
            }
        }

        public int Update(Towns obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "update Towns set Name = @Name, CountryId = @CountryId where Id=@Id";
                return connection.Execute(str, obj);
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "delete from Towns where id = @Id";
                return connection.Execute(str, new { Id = id });
            }
        }

        public IEnumerable<Towns> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select Id,Name,CountryId from Towns";
                return connection.Query<Towns>(str);
            }
        }

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

    }
}
