using FinancialAdvisorAppUI.Contracts.Models;
using FinancialAdvisorAppUI.Models.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Models.Users
{
    public class Goal : UserData
    {

        [DisplayName("Due Name")]
        public DateTime DueDate { get; set; }
        public string Justification { get; set; }
        public int? FinanceTypeId { get; set; }
        [DisplayName("Goal Value")]
        public decimal GoalValue { get; set; }
        [DisplayName("Goal Start Date")]
        public DateTime GoalStartDate { get; set; }
        [DisplayName("Type of goal")]
        public virtual FinanceType FinanceType { get; set; }

        public string FinanceDesc { get; set; }

        public Goal(int userId)
        {
            UserId = userId;
        }

        public Goal(int userId, string justification)
        {
            UserId = userId;
            Justification = justification;
        }




        public Goal()
        {

        }

    }
}
