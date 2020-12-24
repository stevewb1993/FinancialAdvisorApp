using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Ref
{
    [Table("FinanceTypes", Schema ="Ref")]
    public partial class FinanceType
    {
        public FinanceType()
        {
            FinancialData = new HashSet<FinancialStat>();
            FinancialGoals = new HashSet<FinancialGoal>();
            UserGoals = new HashSet<UserGoal>();
        }

        [Key] 
        public int Id { get; set; }
        public string FinanceDesc { get; set; }

        public virtual ICollection<FinancialStat> FinancialData { get; set; }
        public virtual ICollection<FinancialGoal> FinancialGoals { get; set; }
        public virtual ICollection<UserGoal> UserGoals { get; set; }
    }
}
