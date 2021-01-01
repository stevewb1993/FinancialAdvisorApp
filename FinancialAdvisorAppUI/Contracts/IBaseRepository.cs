using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(string url, int id);
        Task<bool> CheckUserHasRecords(string url, int id);
        Task<bool> CheckUserHasRecords(string url, int id, DateTime effectiveDate);
        Task<IList<T>> GetByUserId(string url, int id);
        //Task<IList<T>> GetByUserId(string url, int id, DateTime effectiveDate);
        Task<IList<T>> Get(string url);
        Task<bool> Create(string url, T obj);
        Task<bool> Update(string url, T obj, int id);
        Task<bool> Delete(string url, int id);
    }
}
