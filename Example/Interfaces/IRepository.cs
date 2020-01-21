using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Interfaces
{
    public interface IRepository
    
    {
        IQueryable<T>GetAll<T>() where T : class;
        void Insert<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        
    }
}