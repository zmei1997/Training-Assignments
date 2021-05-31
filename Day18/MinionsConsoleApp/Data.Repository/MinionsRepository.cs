using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Model;

namespace Data.Repository
{
    public class MinionsRepository : IRepository<Minions>
    {
        DbHelper helper;
        public MinionsRepository()
        {
            helper = new DbHelper();
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "delete from Minions where Id=@Id";
                return connection.Execute(str, new { Id = id });
            }
        }

        public IEnumerable<Minions> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select Id,name,age,townId from Minions";
                return connection.Query<Minions>(str);
            }
        }

        public Minions GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select name,age,townId from Minions where Id = @Id";
                return connection.QueryFirstOrDefault<Minions>(str, new { Id = id });
            }
        }

        public int Insert(Minions obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "insert into Minions values(@Name, @Age, @TownId)";
                return connection.Execute(str, obj);
            }
        }

        public int Update(Minions obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "update Minions set Name = @Name, Age = @Age, TownId = @TownId where Id=@Id";
                return connection.Execute(str, obj);
            }
        }

        public Dictionary<string, int> GetMinionByVillainId(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select m.Name as name, m.Age as age from MinionsVillains mv inner join Villains v on mv.VillainId = v.Id inner join Minions m on mv.MinionId = m.Id where v.Id = @Id order by name asc";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string, int> map = new Dictionary<string, int>();
            while (reader.Read())
            {
                string name = Convert.ToString(reader["name"]);
                int age = Convert.ToInt32(reader["age"]);
                if (name != null)
                {
                    map.Add(name, age);
                }
                else
                {
                    Console.WriteLine("(no minions)");
                }
            }
            sqlConnection.Close();
            return map;

        }

        public int GetIdByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from Minions where name = @name";
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
