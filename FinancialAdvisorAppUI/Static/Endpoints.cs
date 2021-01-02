using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Static
{
    public static class Endpoints
    {
#if DEBUG
        public static string BaseUrl = "https://localhost:44340/";
#else


#endif
        public static string GoalsEndpoint = $"{BaseUrl}api/goals/";
        public static string UserDetailsEndpoint = $"{BaseUrl}api/userdetails/";
        public static string FinanceTypesEndpoint = $"{BaseUrl}api/financetypes/";
        public static string FinancialStatsEndpoint = $"{BaseUrl}api/financialstats/";
        public static string BooksEndpoint = $"{BaseUrl}api/books/";
        public static string RegisterEndpoint = $"{BaseUrl}api/users/register/";
        public static string LoginEndpoint = $"{BaseUrl}api/users/login/";
        public static string GoalGenerationEndpoint = $"{BaseUrl}api/GoalGeneration/";

    }

    public static class AppConstants
    {
        //public const string UserId = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        public const string UserId = "FriendlyUserId";
        public const string LinkFinanceTracking = "/financetracking/";
        public const string LinkGoals = "/goals/";
        public const string LinkGoalsUpdate = "/goals/create/";
        public const string LinkUserDetails = "/userdetails/";
        public const string LinkLogin = "/login/";
        public const string LinkRegister = "/register/";
        public const string LinkLogout = "/logout/";
        public const string LinkDashboard = "/dashboard/";
    }
}
