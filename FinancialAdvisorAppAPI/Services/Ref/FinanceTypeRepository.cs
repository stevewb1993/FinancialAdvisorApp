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
    public class FinanceTypeRepository : GenericRepository<FinanceType>, IFinanceTypeRepository
    {
        public FinanceTypeRepository(ApplicationDbContext db, DbSet<FinanceType> dbTable) : base(db, dbTable)
        {

        }
    }
}
