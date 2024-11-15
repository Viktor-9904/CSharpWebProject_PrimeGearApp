using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Data.Repository
{
    public class BaseRepositery<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly PrimeGearDbContext dbContext;
        private readonly DbSet<TType> dbSet;
        public BaseRepositery(PrimeGearDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }
        public TType GetById(TId id)
        {
            TType entity = this.dbSet.Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await this.dbSet.FindAsync(id);

            return entity;
        }
        public IEnumerable<TType> GetAll()
        {
            return this.dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return this.dbSet.AsQueryable();
        }

        public void Add(TType item)
        {
            this.dbSet.Add(item);
        }

        public async Task AddAsync(TType item)
        {
            await this.dbSet.AddAsync(item);
        }

        public void AddRange(TType[] items)
        {
            this.dbSet.AddRange(items);
        }

        public async Task AddRangeAsync(TType[] items)
        {
            await this.dbSet.AddRangeAsync(items);
        }

        public bool Delete(TId id)
        {
            TType entityToRemove = GetById(id);

            if (entityToRemove == null)
            {
                return false;
            }
            this.dbSet.Remove(entityToRemove);
            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType entityToRemove = await GetByIdAsync(id);

            if (entityToRemove == null)
            {
                return false;
            }
            this.dbSet.Remove(entityToRemove);
            return true;
        }

        public bool Update(TType entity)
        {
            try
            {
                this.dbSet.Attach(entity);
                this.dbSet.Entry(entity).State = EntityState.Modified;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType entity)
        {
            try
            {
                this.dbSet.Attach(entity);
                this.dbSet.Entry(entity).State = EntityState.Modified;

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
