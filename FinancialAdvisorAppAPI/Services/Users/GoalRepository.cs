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
        public GoalRepository(ApplicationDbContext db) : base(db)
        {
            
        }
        
    }
}
