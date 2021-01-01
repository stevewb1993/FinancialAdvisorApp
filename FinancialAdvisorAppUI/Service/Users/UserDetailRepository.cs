using Blazored.LocalStorage;
using FinancialAdvisorAppUI.Contracts;
using FinancialAdvisorAppUI.Contracts.Users;
using FinancialAdvisorAppUI.Models;
using FinancialAdvisorAppUI.Models.Users;
using FinancialAdvisorAppUI.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Service.Users
{
    public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public UserDetailRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<bool> CheckUserHasCompletedDetailsForm(int userId)
        {

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetBearerToken());

            try
            {
                UserDetail user = await _client.GetFromJsonAsync<UserDetail>(Endpoints.UserDetailsEndpoint + userId);
                if (user.HighestEducation != null) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
