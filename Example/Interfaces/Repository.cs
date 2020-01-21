
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Interfaces
{
    public class Repository : IRepository
    {
        private readonly IMyDbContext _context;

        public Repository(IMyDbContext context)
        {
            _context = context;               
        }

        public IDbSet<T> GetEntity<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Insert<T>(T entity) where T : class
        {
            GetEntity<T>().Add(entity);
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            GetEntity<T>().Remove(entity);
        }        
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual void Update<T>(T entity, params Expression<Func<T, object>>[] updatedProperties) where T : class
        {
            //dbEntityEntry.State = EntityState.Modified; --- I cannot do this.

            //Ensure only modified fields are updated.
            var dbEntityEntry = _context.Entry(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                //no items mentioned, so find out the updated entries
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                        dbEntityEntry.Property(property).IsModified = true;
                }
            }
        }
        
        /*        public IQueryable<T> GetEntities<T>() where T : class
        {
            return GetEntity<T>().AsQueryable();
        }*/

    }
}
