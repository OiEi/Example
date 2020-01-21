using Example.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Example.Interfaces
{
    public interface IMyDbContext : IDisposable
    {

        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        
        
        //IDbSet<T>Find<T>(T id) where T : class;
    }
}