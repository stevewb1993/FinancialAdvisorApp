using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Static
{
    public static class Endpoints
    {

        public static string BaseUrl = "https://localhost:44340/";

        public static string AuthorsEndpoint = $"{BaseUrl}api/authors/";
        public static string BooksEndpoint = $"{BaseUrl}api/books/";
        public static string RegisterEndpoint = $"{BaseUrl}api/users/register/";
        public static string LoginEndpoint = $"{BaseUrl}api/users/login/";

    }

    public static class AppConstants
    {
        public const string UserId = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    }
}
