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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<FinancialStat> FinancialStats { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
