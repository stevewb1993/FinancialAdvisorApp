using AutoMapper;
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
    public class GoalGenerator
    {
        private readonly UserDetail userDetail;
        private readonly List<FinanceType> financeTypeList;
        private readonly List<FinancialStat> financialStats;
        private const string savingsFinanceId = "3";

        public GoalGenerator(UserDetail userDetail, List<FinanceType> financeTypeList, List<FinancialStat> financialStats)
        {
            this.userDetail = userDetail;
            this.financeTypeList = financeTypeList;
            this.financialStats = financialStats;
        }

        public List<Goal> GenerateGoals ()
        {

            List<Goal> goalList = new List<Goal>();

            List<FinancialStat> latestFinances = FinancialStatsCalculator.getLatestFinanceData(financialStats);

            //test short term savings goal
            Goal shortTermSavingsGoal = TestShortTermSaving(latestFinances);
            if (shortTermSavingsGoal != null) goalList.Add(shortTermSavingsGoal);

            return goalList;

        }

        public Goal TestShortTermSaving(List<FinancialStat> latestFinances)
        {
            //calculate required savings
            int monthsOfSavingRequired = 6;
            decimal requiredMonthlyExpenses = latestFinances.Where(f => f.FinanceType.Category == "Outgoings").Select(f => f.FinanceValue).Sum();
            decimal requiredSavings = requiredMonthlyExpenses * monthsOfSavingRequired;

            //calculate actual savings
            decimal actualSavings = latestFinances.Where(f => f.FinanceType.Category == "Asset" & f.FinanceType.Liquidity == "Liquid").Select(f => f.FinanceValue).Sum();

            //evaluate
            if (actualSavings >= requiredSavings) return null;

            //construct goal if needed
            decimal extraSavingsRequired = requiredSavings - actualSavings;

            DateTime dueDate = DateTime.Now.AddDays(365);
            string justification = $"In order to manage your risk, it is important to have 6 months of savings to cover your non-optional expenses. \r\n" +
                $"An additional {extraSavingsRequired} of saving would allow you to reach this";

            FinanceType goalFinanceType = financeTypeList.Where(f => f.Id == 3).FirstOrDefault();

            Goal liquidSavingsGoal = new Goal(dueDate,3, requiredSavings, DateTime.Now, userDetail.Id, goalFinanceType, justification);

            return liquidSavingsGoal;
        }


    }


}
