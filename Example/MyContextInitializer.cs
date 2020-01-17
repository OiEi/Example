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
                var stud1 = new Student { Name = "Ivan" };
                repo.Insert(stud1);
                repo.SaveChanges();
            }
        }
    }
}