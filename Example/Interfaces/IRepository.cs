using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student product);
    }
}