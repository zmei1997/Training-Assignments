using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Model;

namespace Data.Repository
{
    public class MinionsVillainsRepository : IRepository<MinionsVillains>
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MinionsVillains> GetAll()
        {
            throw new NotImplementedException();
        }

        public MinionsVillains GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(MinionsVillains obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into MinionsVillains values(@minionId, @villainId)";
            cmd.Parameters.AddWithValue("@minionId", obj.MinionId);
            cmd.Parameters.AddWithValue("@villainId", obj.VillainId);
            cmd.Connection = sqlConnection;
            int effectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows;
        }

        public int Update(MinionsVillains obj)
        {
            throw new NotImplementedException();
        }
    }
}
