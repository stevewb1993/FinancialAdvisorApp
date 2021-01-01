using FinancialAdvisorAppAPI.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts
{
    public interface IRepositoryBase<T> where T : ApplicationData
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(int id);
        Task<bool> isExists(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}