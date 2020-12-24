using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Contracts.Data;
using FinancialAdvisorAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services
{
    public class GenericRepository<T> : IRepositoryBase<T> where T: ApplicationData
    {
        public  ApplicationDbContext _db;
        public DbSet<T> _dbTable;

        public GenericRepository(ApplicationDbContext db, DbSet<T> dbTable)
        {
            _db = db;
            _dbTable = dbTable;
        }

        public async Task<bool> Create(T entity)
        {
            await _dbTable.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(T entity)
        {
            _dbTable.Remove(entity);
            return await Save();
        }

        public async Task<IList<T>> FindAll()
        { 
            return await _dbTable.ToListAsync();
        }

        public async Task<T> FindById(IComparable id)
        {
            return await _dbTable.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _dbTable.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(T entity)
        {
            _dbTable.Update(entity);
            return await Save();
        }
    }
}
