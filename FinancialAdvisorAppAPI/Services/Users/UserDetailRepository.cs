using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data;
using FinancialAdvisorAppAPI.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Services.Users
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public UserDetailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(UserDetail entity)
        {
            await _db.UserDetails.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(UserDetail entity)
        {
            _db.UserDetails.Remove(entity);
            return await Save();
        }

        public async Task<IList<UserDetail>> FindAll()
        {
            return await _db.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> FindById(IComparable id)
        {
            return await _db.UserDetails.FirstOrDefaultAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> isExists(IComparable id)
        {
            return await _db.UserDetails.AnyAsync(q => q.Id.ToString() == id.ToString());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(UserDetail entity)
        {
            _db.UserDetails.Update(entity);
            return await Save();
        }
    }
}
