using Example.Interfaces;
using Example.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Example
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext() : base ("StudentDB")
        {
        }

        static MyDbContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Student>();
            base.OnModelCreating(modelBuilder);
        }
    }
}