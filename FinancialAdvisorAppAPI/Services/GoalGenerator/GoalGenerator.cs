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
    public static class GoalGenerator
    {

        private const string savingsFinanceId = "3";


        private static List<string> testRequirementShortTermSavings = new List<string>{"3", "6", "11"};

        //private KeyValuePair<string, List<string>> = new KeyValuePair<string, List<string>>

        private static Dictionary<string, List<string>> testRequirementsDictionary = new Dictionary<string, List<string>>() 
        {
            { "shortTermSavings", new List<string>{"3", "6"} }
        
        };

        public static List<Goal> GenerateGoals (UserDetail userDetail, List<FinancialStat> financialStatsList, List<FinanceType> financeTypeList)
        {

            string userId = userDetail.Id;
            List<Goal> goalList = new List<Goal>();

            List<FinancialStat> latestFinances = FinancialStatsCalculator.getLatestFinanceData(financialStatsList, financeTypeList);

            List<string> financeTypesProvidedByUser = latestFinances.Select(x => x.FinanceType.Id).ToList();



            decimal liquidSavings;



            if(financeTypesProvidedByUser.Contains)

            Goal shortTermSavingsGoal = TestShortTermSaving()
            
            goalList.Add(exampleGoal);
            goalList.Add(exampleGoal2);
            return goalList;
        }

        public static Goal TestShortTermSaving(decimal liquidSavings, decimal monthlyExpenses, string userId, List<FinanceType> financeTypeList)
        {
            
            int monthsOfSavingRequired = 6;
            decimal requiredSavings = monthlyExpenses * monthsOfSavingRequired;
            
            if (liquidSavings > requiredSavings) return null;

            DateTime dueDate = DateTime.Now.AddDays(365);
            FinanceType financeType = financeTypeList.Where(x => x.Id == savingsFinanceId).FirstOrDefault();
            string goalId = Guid.NewGuid().ToString();
            string justification = $"In order to manage your risk, it is important to have 6 months of savings to cover your non-optional expenses";

            Goal liquidSavingsGoal = new Goal(dueDate, savingsFinanceId, requiredSavings, DateTime.Now, userId, goalId, financeType, justification);

            return liquidSavingsGoal;
        }

        private static Dictionary<string, bool> evaluateRelevantTests(List<FinancialStat> userFinances)
        {
            
            
            List<string> financeTypesProvidedByUser = userFinances.Select(x => x.FinanceType.Id).ToList();

            //check for TestShortTermSaving

            if (financeTypesProvidedByUser.Contains("3") | financeTypesProvidedByUser.Contains("6"))
        }

        private static bool hasSavings(List<FinancialStat> financialStats)
        {
            return FinanceTypesProvidedByUser.Contains("3") | FinanceTypesProvidedByUser.Contains("6");
        }

        private static bool hasExpenses(List<String> FinanceTypesProvidedByUser)
        {
            return FinanceTypesProvidedByUser.Contains("3") | FinanceTypesProvidedByUser.Contains("6");
        }






    }


}
