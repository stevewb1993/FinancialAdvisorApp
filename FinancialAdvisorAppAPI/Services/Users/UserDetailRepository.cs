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
    public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(ApplicationDbContext db, DbSet<UserDetail> dbTable) : base(db, dbTable)
        {

        }
    }

}
