using Example.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Example.Interfaces
{
    public interface IMyDbContext
    {
        DbSet<Student> Students { get; set; }
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Dispose();
    }
}