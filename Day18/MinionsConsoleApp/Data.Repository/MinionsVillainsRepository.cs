using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Model;

namespace Data.Repository
{
    public class MinionsVillainsRepository : IRepository<MinionsVillains>
    {
        DbHelper helper;
        public MinionsVillainsRepository() {
            helper = new DbHelper();
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "delete from MinionsVillains where MinionId = @MinionId";
                return connection.Execute(str, new { MinionId = id });
            }
        }

        public IEnumerable<MinionsVillains> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select MinionId, VillainId from MinionsVillains";
                return connection.Query<MinionsVillains>(str);
            }
        }

        public MinionsVillains GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "select MinionId, VillainId from MinionsVillains where MinionId = @MinionId";
                return connection.QueryFirstOrDefault<MinionsVillains>(str, new { MinionId = id });
            }
        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(MinionsVillains obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "insert into MinionsVillains values(@MinionId, @VillainId)";
                return connection.Execute(str, obj);
            }
        }

        public int Update(MinionsVillains obj)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "update MinionsVillains set VillainId = @VillainId where MinionId=@MinionId";
                return connection.Execute(str, obj);
            }
        }
    }
}
