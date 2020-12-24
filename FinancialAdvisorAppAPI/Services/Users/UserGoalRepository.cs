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
    public class UserGoalRepository : IUserGoalRepository
    {
        private readonly ApplicationDbContext _db;

        public UserGoalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(UserGoal entity)
        {
            await _db.UserGoals.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(UserGoal entity)
        {
            _db.UserGoals.Remove(entity);
            return await Save();
        }

        public async Task<IList<UserGoal>> FindAll()
        {
            return await _db.UserGoals.ToListAsync();
        }

        public async Task<UserGoal> FindById(IComparable id)
        {
            return await _db.UserGoals.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _db.UserGoals.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(UserGoal entity)
        {
            _db.UserGoals.Update(entity);
            return await Save();
        }
    }
}
