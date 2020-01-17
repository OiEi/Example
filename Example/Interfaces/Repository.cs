
using System.Data.Entity;
using System.Linq;


namespace Example.Interfaces
{
    public class Repository : IRepository
    {
        private readonly IMyDbContext _context;
                
        public Repository(IMyDbContext context)
        {
            _context = context;               
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return GetEntities<T>().AsQueryable();
        }

        public void Insert<T>(T entity) where T : class
        {
            GetEntities<T>().Add(entity);
        }

        private IDbSet<T> GetEntities<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

/*        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == id);
        }*/

        /*public void Add(Student product)
        {
            _context.Students.Add(product);
            _context.SaveChanges();
        }*/

        /*protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }*/

        /*public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/

    }
}