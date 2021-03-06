﻿using FinancialAdvisorAppUI.Models;
using FinancialAdvisorAppUI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Contracts.Users

{
    public interface IUserDetailRepository : IBaseRepository<UserDetail>
    {
        Task<bool> CheckUserHasCompletedDetailsForm(int userId);
    }
}
