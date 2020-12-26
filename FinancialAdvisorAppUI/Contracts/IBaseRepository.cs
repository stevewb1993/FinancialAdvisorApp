using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(string url, string id);
        Task<bool> CheckUserHasRecords(string url, string id);
        Task<IList<T>> GetByUserId(string url, string id);
        Task<IList<T>> Get(string url);
        Task<bool> Create(string url, T obj);
        Task<bool> Update(string url, T obj, string id);
        Task<bool> Delete(string url, string id);
    }
}
