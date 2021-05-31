using System;
using System.Collections.Generic;
using System.Text;
using DapperTutorial.Data.Repository;
using DapperTutorial.Data.Model;
using System.Linq;
namespace DapperTutorial
{
    class ManageDepartment
    {
        //IRepositoryAsync<Dept> deptRepositoryAsync;
        IRepository<Dept> deptRepository;
        public ManageDepartment()
        {
            //deptRepositoryAsync = new DeptRepository();
            deptRepository = new DeptRepository();
        }

        void PrintAll()
        {
            var collection = deptRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.DName + "\t" + item.Loc);
            }
        }

        void AddDepartment()
        {
            var d = new Dept();
            Console.Write("Enter department name: ");
            var dname = Console.ReadLine();
            Console.Write("Enter department location: ");
            var dloc = Console.ReadLine();
            d.DName = dname;
            d.Loc = dloc;

            deptRepository.Insert(d);
        }

        void UpdateDepartment()
        {
            Console.Write("Enter department name you want to update: ");
            var dname = Console.ReadLine();
            Console.Write("Enter a new department location: ");
            var dloc = Console.ReadLine();
            var dept = deptRepository.GetAll().Where(item => item.DName == dname).FirstOrDefault();
            dept.Loc = dloc;
            deptRepository.Update(dept);
        }

        void DeleteDepartment()
        {
            Console.Write("Enter department name you want to delete: ");
            var dname = Console.ReadLine();
            var dept = deptRepository.GetAll().Where(item => item.DName == dname).FirstOrDefault();
            deptRepository.Delete(dept.Id);
        }

        //async void PrintAll()
        //{
        //    List<Dept> deptCollection = new List<Dept>();
        //    var collection = await deptRepositoryAsync.GetAllAsync();
        //    deptCollection.AddRange(collection);
        //    var d = await deptRepositoryAsync.GetByIdAsync(3010);
        //    deptCollection.Add(d);
        //    foreach (var item in collection)
        //    {
        //        Console.WriteLine(item.Id + "\t" + item.DName + "\t" + item.Loc);
        //    }
        //}

        public void Run()
        {
            //PrintAll();
            //AddDepartment();
            //UpdateDepartment();
            DeleteDepartment();
        }
    }
}
