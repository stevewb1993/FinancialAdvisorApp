using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Ref
{
    public partial class FinanceType
    {
        public FinanceType()
        {
            FinancialData = new HashSet<FinancialStat>();
            FinancialGoals = new HashSet<FinancialGoal>();
            UserGoals = new HashSet<UserGoal>();
        }

        public int FinanceTypeId { get; set; }
        public string FinanceDesc { get; set; }

        public virtual ICollection<FinancialStat> FinancialData { get; set; }
        public virtual ICollection<FinancialGoal> FinancialGoals { get; set; }
        public virtual ICollection<UserGoal> UserGoals { get; set; }
    }
}
