using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data;
using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services.Ref
{
    public class FinanceTypeRepository : IFinanceTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FinanceTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(FinanceType entity)
        {
            await _db.FinanceTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(FinanceType entity)
        {
            _db.FinanceTypes.Remove(entity);
            return await Save();
        }

        public async Task<IList<FinanceType>> FindAll()
        {
            return await _db.FinanceTypes.ToListAsync();
        }

        public async Task<FinanceType> FindById(IComparable id)
        {
            return await _db.FinanceTypes.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _db.FinanceTypes.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(FinanceType entity)
        {
            _db.FinanceTypes.Update(entity);
            return await Save();
        }
    }
}
