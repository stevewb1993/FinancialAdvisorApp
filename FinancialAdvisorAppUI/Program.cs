using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Blazored.Toast;
using FinancialAdvisorAppUI.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using FinancialAdvisorAppUI.Contracts;
using FinancialAdvisorAppUI.Service;
using FinancialAdvisorAppUI.Contracts.Users;
using FinancialAdvisorAppUI.Service.Users;
using FinancialAdvisorAppUI.Contracts.Ref;
using FinancialAdvisorAppUI.Service.Ref;

namespace FinancialAdvisorAppUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            _ = new JwtHeader();
            _ = new JwtPayload();


            builder.Services.AddScoped(sp => new HttpClient
            { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddTransient<IFinancialStatRepository, FinancialStatRepository>();
            builder.Services.AddTransient<IGoalRepository, GoalRepository>();
            builder.Services.AddTransient<IUserDetailRepository, UserDetailRepository>();
            builder.Services.AddTransient<IFinanceTypeRepository, FinanceTypeRepository>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            //builder.Services.AddTransient<IFileUpload, FileUpload>();
            await builder.Build().RunAsync();
        }
    }
}
