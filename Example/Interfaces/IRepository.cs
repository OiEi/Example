using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Interfaces
{
    public interface IRepository
    
    {
        IQueryable<T>GetAll<T>() where T : class;
        void Insert<T>(T entity) where T : class;
        //Student GetById(int id);
        //void Add(Student product);
    }
}