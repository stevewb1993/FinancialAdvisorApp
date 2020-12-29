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
    public class GenericUserRepository<T> : GenericRepository<T>, IUserRepositoryBase<T> where T : UserData
    {
        public GenericUserRepository(ApplicationDbContext db, DbSet<T> dbTable) : base(db, dbTable)
        {
        }


        public virtual async Task<IList<T>> FindAllByUserId(string userId)
        {
            return await _dbTable
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }

    }
}
