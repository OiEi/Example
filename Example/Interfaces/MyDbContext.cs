using Example.Interfaces;
using Example.Models;

using System.Data.Entity;

namespace Example
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext() : base ("StudentDB")
        {
        }
        public DbSet<Student> Students { get; set; }

    }
}