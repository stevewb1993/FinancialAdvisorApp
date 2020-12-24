using FinancialAdvisorAppAPI.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts
{
    public interface IUserRepositoryBase<T> : IRepositoryBase<T> where T : UserData
    {
        Task<IList<T>> FindAllByUserId(string userId);
    }
}