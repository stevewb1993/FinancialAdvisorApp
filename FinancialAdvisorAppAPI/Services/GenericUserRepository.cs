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
    public abstract class GenericUserRepository<T> : GenericRepository<T> where T : UserData
    {
        public GenericUserRepository(ApplicationDbContext db, DbSet<T> dbTable) : base(db, dbTable)
        {
        }
    }
}
