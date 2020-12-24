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
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        private readonly ApplicationDbContext _db;

        public FinancialGoalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(FinancialGoal entity)
        {
            await _db.FinancialGoals.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(FinancialGoal entity)
        {
            _db.FinancialGoals.Remove(entity);
            return await Save();
        }

        public async Task<IList<FinancialGoal>> FindAll()
        {
            return await _db.FinancialGoals.ToListAsync();
        }

        public async Task<FinancialGoal> FindById(IComparable id)
        {
            return await _db.FinancialGoals.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<IList<FinancialGoal>> FindAllByUserId(string userId)
        {
            return await _db.FinancialGoals
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _db.FinancialGoals.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(FinancialGoal entity)
        {
            _db.FinancialGoals.Update(entity);
            return await Save();
        }
    }
}
