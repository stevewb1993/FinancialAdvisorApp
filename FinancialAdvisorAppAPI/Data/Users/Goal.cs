using FinancialAdvisorAppAPI.Contracts.Data;
using FinancialAdvisorAppAPI.Data.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("Goals", Schema = "users")]
    public partial class Goal : UserData
    {
        
        public DateTime DueDate { get; set; }
        public string FinanceTypeId { get; set; }
        public decimal GoalValue { get; set; }
        public DateTime GoalStartDate { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
