using System;
using System.Collections.Generic;
using System.Text;
using FinancialAdvisorAppAPI.Data.Users;
using FinancialAdvisorAppAPI.Data.Ref;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialAdvisorAppAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<FinancialStat> FinancialStats { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Goal> Goals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
