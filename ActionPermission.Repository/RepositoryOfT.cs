using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ActionPermission.Context;
using ActionPermission.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ActionPermission.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> Set
        {
            get
            {
                return context.Set<T>();
            }
        }
        private ActionPermissionContext context;
        public Repository(ActionPermissionContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await Set.AddAsync(entity);
        }

        public T Query(Expression<Func<T, bool>> predicate)
        {
            return Set.First(predicate);
        }

        public async Task<T> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await Set.FirstAsync(predicate);
        }

        public ICollection<T> QueryList(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate).ToList();
        }

        public async Task<ICollection<T>> QueryListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Set.Where(predicate).ToListAsync();
        }


        public void SaveChange()
        {
            context.SaveChanges();
        }

        public Task SaveChangeAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Update<Tkey>(T entity, Tkey key)
        {
            var e = Set.Find(key);
            if(e == null)
            {
                throw new InvalidOperationException("entity does not exists");
            }
            Set.Update(entity);
        }

        public async Task UpdateAsync<Tkey>(T entity, Tkey key)
        {
            var e = await  Set.FindAsync(key);
            if (e == null)
            {
                throw new InvalidOperationException("entity does not exists");
            }
            Set.Update(e);
        }

        public void Delete<TKey>(T entity, TKey key)
        {
            var e = Set.Find(key);
            if(e == null)
            {
                throw new InvalidOperationException("entity does not exists");
            }
            Set.Remove(entity);
        }

        public async Task DeleteAsync<TKey>(T entity, TKey key)
        {
            var e = await Set.FindAsync(key);
            if(e == null)
            {
                throw new InvalidOperationException("entity does not exists");
            }
            Set.Remove(entity);
        }
    }
}
