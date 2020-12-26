using Blazored.LocalStorage;
using FinancialAdvisorAppUI.Contracts;
using FinancialAdvisorAppUI.Contracts.Users;
using FinancialAdvisorAppUI.Models;
using FinancialAdvisorAppUI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Service.Users
{
    public class GoalRepository : BaseRepository<Goal>, IGoalRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public GoalRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
