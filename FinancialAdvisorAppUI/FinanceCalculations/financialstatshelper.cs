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

        public static List<FinancialStat> AggregateDailyFinancialStatsValue(List<FinancialStat> finstats)
        {

            return finstats
                .GroupBy(g => new
                    {
                        g.FinanceDate,
                        g.FinanceTypeId
                    })
                    .Select(g => new FinancialStat
                    {
                        FinanceDate = g.Key.FinanceDate,
                        FinanceTypeId = g.Key.FinanceTypeId,
                        FinanceValue = g.Sum(x => x.FinanceValue)

                    })
                    .ToList();
   
        }

        public static  Dictionary<FinanceType, List<FinancialStat>> RemoveEmptyCategories(Dictionary<FinanceType, List<FinancialStat>> userFinanceDictionary)
        {
            Dictionary<FinanceType, List<FinancialStat>> cleanedFinanceStats = new Dictionary<FinanceType, List<FinancialStat>>();

            foreach(var entry in userFinanceDictionary)
            {
                cleanedFinanceStats.Add(entry.Key, entry.Value);
            }

            cleanedFinanceStats = userFinanceDictionary;
            List<FinanceType> financeTypesToRemove = new List<FinanceType>();

            //loopThroughEachCategory
            foreach (var financeTypeTimeSeries in cleanedFinanceStats)
            {
                bool allEntriesAreZero = true;
                //loop through each date to check if there is a non-zero value. As soon as one is found, break from the loop

                foreach (var finStat in financeTypeTimeSeries.Value)
                {
                    if (finStat.FinanceValue != 0)
                    {
                        allEntriesAreZero = false;
                        break;
                    }
                }
                
                //if all entries were zero, the finance type can be added to the list to remove
                if (allEntriesAreZero) financeTypesToRemove.Add(financeTypeTimeSeries.Key);
            }

            //remove the all zero finance types
            foreach (var financetype in financeTypesToRemove)
            {
                cleanedFinanceStats.Remove(financetype);
            }

            return cleanedFinanceStats;
        }

    }
}
