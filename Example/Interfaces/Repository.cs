using Example.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Example.Interfaces
{
    public class Repository : IRepository
    {
        //private MyDbContext db = new MyDbContext();

        private IMyDbContext _context;
        public Repository(IMyDbContext repository)
        {
            _context = repository;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Student product)
        {
            _context.Students.Add(product);
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}