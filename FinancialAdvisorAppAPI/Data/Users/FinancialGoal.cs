using FinancialAdvisorAppAPI.Data.AspNet;
using FinancialAdvisorAppAPI.Data.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("FinancialGoals", Schema = "users")]
    public partial class FinancialGoal
    {
        [Key]
        public int GoalId { get; set; }
        public string UserId { get; set; }
        public DateTime DueDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal GoalValue { get; set; }
        public DateTime GoalStartDate { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
