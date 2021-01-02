using FinancialAdvisorAppUI.Models.Ref;
using FinancialAdvisorAppUI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.FinanceCalculations
{
    public static class FinancialStatsHelper
    {
        public static Dictionary<FinanceType, List<FinancialStat>> SplitOutFinancialStatsByCategory(List<FinanceType> financeTypes, List<FinancialStat> finStats)
        {
            Dictionary<FinanceType, List<FinancialStat>> brokenDownFinanceStats = new Dictionary<FinanceType, List<FinancialStat>>();
            foreach (var finType in financeTypes)
            {
                brokenDownFinanceStats.Add(finType, finStats.Where(f => f.FinanceTypeId == finType.Id).ToList());
            }
            return brokenDownFinanceStats;
        }

        public static List<FinancialStat> AggregateDailyFinancialStats(List<FinancialStat> finstats)
        {
            return null;
        }

    }
}
