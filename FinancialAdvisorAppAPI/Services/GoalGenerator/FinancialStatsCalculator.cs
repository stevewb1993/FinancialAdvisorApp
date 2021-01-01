using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services.GoalGenerator
{
    public static class FinancialStatsCalculator
    {
        /// <summary>
        /// gets the latest financial stats information for the user for each given financial type
        /// </summary>
        /// <param name="userFinances"></param>
        /// <param name="financeTypes"></param>
        /// <returns></returns>
        public static List<FinancialStat> getLatestFinanceData(IList<FinancialStat> userFinances)
        {
            DateTime latestDate = userFinances.Select(x => x.FinanceDate).Max();
            return userFinances.Where(x => x.FinanceDate == latestDate).ToList();
        }



        /// <summary>
        /// calculate full disposable income. userFinances must be provided with the latest financial data
        /// </summary>
        /// <param name="userFinances"></param>
        /// <returns></returns>
        public static decimal calculateDisposableIncome (List<FinancialStat> userFinances)
        {
            return CalculateIncomings(userFinances) + CalculateCapitalIncome(userFinances) - CalculateOutgoings(userFinances) - CalculateCapitalExpense(userFinances);
        }

        /// <summary>
        /// calculate monthly outgoings excluding liabilities. userFinances must be provided with the latest financial data
        /// </summary>
        /// <param name="userFinances"></param>
        /// <returns></returns>
        static decimal CalculateOutgoings(List<FinancialStat> userFinances)
        {
            return userFinances
                .Where(x => x.FinanceType.Category == "Outgoings")
                .Sum(x => x.FinanceValue);
        }

        /// <summary>
        /// calculate monthly income excluding capital income. userFinances must be provided with the latest financial data
        /// </summary>
        /// <param name="userFinances"></param>
        /// <returns></returns>
        public static decimal CalculateIncomings(List<FinancialStat> userFinances)
        {
            return userFinances
                .Where(x => x.FinanceType.Category == "Incomings")
                .Sum(x => x.FinanceValue);
        }

        public static decimal CalculateCapitalIncome(List<FinancialStat> userFinances)
        {
            return userFinances
                .Where(x => x.FinanceType.Category == "Asset")
                .Select(x => x.FinanceValue * x.InterestRate)
                .Sum();
        }

        public static decimal CalculateCapitalExpense(List<FinancialStat> userFinances)
        {
            return userFinances
                .Where(x => x.FinanceType.Category == "Liability")
                .Select(x => x.FinanceValue * (x.InterestRate * 0.01m))
                .Sum();
        }



    }
}
