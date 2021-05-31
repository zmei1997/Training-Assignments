using System;
using System.Collections.Generic;
using System.Text;
using DapperTutorial.Data.Model;
using Dapper;
using System.Data;
using System.Threading.Tasks;
namespace DapperTutorial.Data.Repository
{
    public class DeptRepository : IRepository<Dept>, IRepositoryAsync<Dept>
    {
        DBHelper helper;
        public DeptRepository()
        {
            helper = new DBHelper();
        }
        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("delete from Dept where id=@deptid", new { deptid = id });
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return await connection.ExecuteAsync("delete from Dept where id=@deptid", new { deptid = id });
            }
        }


        public IEnumerable<Dept> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Query<Dept>("Select Id, DName, Loc from Dept");
            }
        }

        public async Task<IEnumerable<Dept>> GetAllAsync()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return await connection.QueryAsync<Dept>("Select Id, DName, Loc from Dept");
            }
        }

        public Dept GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.QueryFirstOrDefault<Dept>("Select Id, DName, Loc from Dept Where id=@deptid", new { deptid = id });
            }
        }
        public async Task<Dept> GetByIdAsync(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Dept>("Select Id, DName, Loc from Dept Where id=@deptid", new { deptid = id });
            }
        }

        public int Insert(Dept item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("insert into Dept values (@DName,@Loc)", item);
            }
        }

        public async Task<int> InsertAsync(Dept item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return await connection.ExecuteAsync("insert into Dept values (@DName,@Loc)", item);
            }
        }

        public int Update(Dept item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("update Dept set Loc=@Loc, DName =@DName where Id=@Id", item);
            }

        }

        public async Task<int> UpdateAsync(Dept item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return await connection.ExecuteAsync("update Dept set Loc=@Loc, DName =@DName where Id=@Id", item);
            }

        }
    }
}
