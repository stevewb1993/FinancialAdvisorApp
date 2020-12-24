using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data;
using FinancialAdvisorAppAPI.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services.Users
{
    public class FinancialStatRepository : IFinancialStatRepository
    {
        private readonly ApplicationDbContext _db;

        public FinancialStatRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(FinancialStat entity)
        {
            await _db.FinancialStats.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(FinancialStat entity)
        {
            _db.FinancialStats.Remove(entity);
            return await Save();
        }

        public async Task<IList<FinancialStat>> FindAll()
        {
            return await _db.FinancialStats.ToListAsync();
        }

        public async Task<FinancialStat> FindById(IComparable id)
        {
            return await _db.FinancialStats.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _db.FinancialStats.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(FinancialStat entity)
        {
            _db.FinancialStats.Update(entity);
            return await Save();
        }
    }
}
