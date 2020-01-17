using Example.Interfaces;
using Example.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Example
{
    public class MyContextInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext db)
        {
            using (var ctx = new MyDbContext())
            {
                var repo = new Repository(ctx);
                var comp1 = new Company {};
                var comp2 = new Company { };
                repo.Insert(comp1);
                repo.Insert(comp2);
                var pasp1 = new Pasport { Type = "RU", Number = "456" };
                var pasp2 = new Pasport { Type = "ENG", Number = "987" };
                var pasp3 = new Pasport { Type = "RU", Number = "123" };
                repo.Insert(pasp1);
                repo.Insert(pasp2);
                repo.Insert(pasp3);
                var empl1 = new Employee { Name = "Роналду", Surname = "Иванов", Phone = "987456321", Pasport = pasp1, Company = comp1 };
                var empl2 = new Employee { Name = "Petia", Surname = "Tarashkevich", Phone = "9876544896", Pasport = pasp2, Company = comp1 };
                var empl3 = new Employee { Name = "Zina", Surname = "Kuzina", Phone = "34521564562", Pasport = pasp3, Company = comp2 };
                repo.Insert(empl1);
                repo.Insert(empl2);
                repo.Insert(empl3);
                repo.SaveChanges();
            }
        }
    }
}