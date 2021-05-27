using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Model;

namespace Data.Repository
{
    public class MinionsRepository : IRepository<Minions>
    {
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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Minions> GetAll()
        {
            throw new NotImplementedException();
        }

        public Minions GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name,age,townId from Minions where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            Minions m = new Minions();
            while (reader.Read())
            {
                string name = Convert.ToString(reader["name"]);
                int age = Convert.ToInt32(reader["age"]);
                int townId = Convert.ToInt32(reader["townId"]);
                m.Name = name;
                m.Age = age;
                m.TownId = townId;
            }
            sqlConnection.Close();
            return m;
        }

        public int Insert(Minions obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Minions values(@name, @age, @townId)";
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@townId", obj.TownId);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public int Update(Minions obj)
        {
            throw new NotImplementedException();
        }
    }
}
