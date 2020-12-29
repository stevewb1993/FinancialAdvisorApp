﻿using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Controllers;
using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services.GoalGenerator
{
    public static class GoalGenerator
    {
        public static List<Goal> GenerateGoals (UserDetail userDetail, IList<FinancialStat> financialStatsList, IList<FinanceType> financeTypeList)
        {
            List<Goal> goalList = new List<Goal>();
            Goal exampleGoal = new Goal(DateTime.Now.AddDays(365), "1", 1000, DateTime.Now, "System", userDetail.Id, Guid.NewGuid().ToString());
            Goal exampleGoal2 = new Goal(DateTime.Now.AddDays(365), "5", 5000, DateTime.Now, "System", userDetail.Id, Guid.NewGuid().ToString());
            goalList.Add(exampleGoal);
            goalList.Add(exampleGoal2);
            return goalList;
        }

        
    }


}
