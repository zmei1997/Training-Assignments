using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class VillainsRepository : IRepository<Villains>
    {
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
        }

        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from Villains where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public IEnumerable<Villains> GetAll()
        {
            throw new NotImplementedException();
        }

        public Villains GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name,EvilnessFactorId from Villains where Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            Villains v = new Villains();
            while (reader.Read())
            {
                string name = Convert.ToString(reader["name"]);
                int evilnessFactorId = Convert.ToInt32(reader["evilnessFactorId"]);
                v.Name = name;
                v.EvilnessFactorId = evilnessFactorId;
            }
            sqlConnection.Close();
            return v;
        }

        public int Insert(Villains obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Villains values(@name, @evilnessFactorId)";
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@evilnessFactorId", obj.EvilnessFactorId);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;

        }

        public int Update(Villains obj)
        {
            throw new NotImplementedException();
        }
    }
}
