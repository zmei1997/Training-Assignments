using System;
using System.Collections.Generic;
using System.Text;
using DapperTutorial.Data.Repository;
using DapperTutorial.Data.Model;
namespace DapperTutorial
{
    class ManageDepartment
    {
        IRepositoryAsync<Dept> deptRepositoryAsync;
        public ManageDepartment()
        {
            deptRepositoryAsync = new DeptRepository();
        }

        async void PrintAll()
        {
            List<Dept> deptCollection = new List<Dept>();
            var collection = await deptRepositoryAsync.GetAllAsync();
            deptCollection.AddRange(collection);
            var d = await deptRepositoryAsync.GetByIdAsync(3010);
            deptCollection.Add(d);
            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.DName + "\t" + item.Loc);
            }
        }

        public void Run()
        {
            PrintAll();
        }
    }
}
