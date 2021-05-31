using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Data.Repository
{
    public class VillainsRepository : IRepository<Villains>
    {
        DbHelper helper;
        public VillainsRepository()
        {
            helper = new DbHelper();
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "delete from Villains where id = @Id";
                return connection.Execute(str, new { Id = id });
            }
        }

        public IEnumerable<Villains> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select Id, Name, EvilnessFactorId from Villains";
                return connection.Query<Villains>(str);
            }
        }

        public Villains GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select name,EvilnessFactorId from Villains where Id = @Id";
                return connection.QueryFirstOrDefault<Villains>(str, new { Id = id });
            }
        }

        public int Insert(Villains obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("insert into Villains values(@name, @evilnessFactorId)", obj);
            }
        }

        public int Update(Villains obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "update Villains set Name = @Name, EvilnessFactorId = @EvilnessFactorId where Id=@Id";
                return connection.Execute(str, obj);
            }
        }

        public Dictionary<string, int> GetVillainsWithNumOfMinions()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select v.Name as Name, count(1) as count from MinionsVillains mv inner join Villains v on mv.VillainId = v.Id group by v.Name having count(1) > 3";
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string, int> map = new Dictionary<string, int>();
            while (reader.Read())
            {
                string name = Convert.ToString(reader["Name"]);
                int count = Convert.ToInt32(reader["count"]);
                map.Add(name, count);
            }

            sqlConnection.Close();
            return map;
        }

        public int GetIdByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from Villains where name = @name";
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
            throw new NotImplementedException();
        }
    }
}
