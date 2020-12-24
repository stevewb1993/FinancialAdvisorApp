using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(IComparable id);
        Task<bool> isExists(IComparable id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}