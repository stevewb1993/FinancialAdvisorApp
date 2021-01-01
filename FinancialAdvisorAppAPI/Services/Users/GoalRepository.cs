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
    public class GoalRepository : GenericUserRepository<Goal>, IGoalRepository
    {
        //public GoalRepository(ApplicationDbContext db, DbSet<Goal> dbTable) : base(db, dbTable)
        //{
        //    
        //}

        public GoalRepository(ApplicationDbContext db) : base(db, db.Goals)
        {

        }

        public override async Task<IList<Goal>> FindAllByUserId(int userId)
        {
            return await _db.Goals
                .Where(g => g.UserId == userId)
                .Include(g => g.FinanceType)
                .ToListAsync();
        }






    }
}
