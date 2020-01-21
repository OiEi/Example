
using System.Collections;
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

        public IDbSet<T> GetEntities<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            GetEntities<T>().Remove(entity);
        }        
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
              
    }
}