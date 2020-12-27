using Blazored.LocalStorage;
using FinancialAdvisorAppUI.Contracts.Users;
using FinancialAdvisorAppUI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Service.Users
{
    public class FinancialStatRepository : BaseRepository<FinancialStat>, IFinancialStatRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public FinancialStatRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
