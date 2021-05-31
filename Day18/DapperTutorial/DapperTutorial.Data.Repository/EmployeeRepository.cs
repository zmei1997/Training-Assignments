using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using DapperTutorial.Data.Model;
namespace DapperTutorial.Data.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        DBHelper helper;
        public EmployeeRepository()
        {
            helper = new DBHelper();
        }
        public int Delete(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("Delete from Employee where id=@empid", new { empid = id });
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "Select e.Id,e.EName,e.Salary,e.DeptId,d.Id,d.DName,d.Loc from Employee e inner join Dept d on e.DeptId=d.Id";
                return connection.Query<Employee, Dept, Employee>(str, (e, d) => { e.Dept = d; return e; });
            }
        }

        public Employee GetById(int id)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                string str = "Select e.Id,e.EName,e.Salary,e.DeptId from Employee e  where e.id=@empid";
                return connection.QueryFirstOrDefault<Employee>(str, new { empid = id });
            }
        }
        public int Insert(Employee item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("insert into Employee values (@EName, @Salary, @DeptId)", item);
            }
        }

        public int Update(Employee item)
        {
            using (IDbConnection connection = helper.GetConnection())
            {
                return connection.Execute("update Employee set EName=@EName, Salary =@Salary, DeptId =@DeptId where Id=@Id", item);
            }
        }
    }
}
