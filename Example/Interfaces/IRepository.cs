
using System.Data.Entity;
using System.Linq;

namespace Example.Interfaces
{
    public interface IRepository
    
    {
        IDbSet<T> GetEntity<T>() where T : class;
        //IQueryable<T>GetEntities<T>() where T : class;
        void Insert<T>(T entity) where T : class;
        void DeleteEntity<T>(T entity) where T : class;
        void SaveChanges();
    }
}
