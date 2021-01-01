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
        public Goal()
        {

        }



        public Goal(DateTime dueDate, int financeTypeId, decimal goalValue, DateTime goalStartDate, int userId, string id, string justification = null)
        {
            DueDate = dueDate;
            FinanceTypeId = financeTypeId;
            GoalValue = goalValue;
            GoalStartDate = goalStartDate;
            Justification = justification;
            UserId = userId;

        }

        public Goal(DateTime dueDate, int financeTypeId, decimal goalValue, DateTime goalStartDate, int userId, FinanceType financeType, string justification = null)
        {
            DueDate = dueDate;
            FinanceTypeId = financeTypeId;
            GoalValue = goalValue;
            GoalStartDate = goalStartDate;
            Justification = justification;
            UserId = userId;
            FinanceType = financeType;

        }

        public DateTime DueDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal GoalValue { get; set; }
        public DateTime? GoalStartDate { get; set; }

        public string Justification { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
