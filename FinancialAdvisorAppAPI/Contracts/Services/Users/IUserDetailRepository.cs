using FinancialAdvisorAppAPI.Data;
using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts
{
    public interface IUserDetailRepository : IRepositoryBase<UserDetail>
    {
        UserDetail FindByUserGuid(string userGuid);

    }
}
