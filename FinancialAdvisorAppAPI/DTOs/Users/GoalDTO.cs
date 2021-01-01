using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.DTOs.Users
{
    public class GoalDTO : DTOBase
    {
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal GoalValue { get; set; }
        public DateTime GoalStartDate { get; set; }

        public string Justification { get; set; }

        public virtual FinanceTypeDTO FinanceType { get; set; }
        //public virtual UserDetailDTO User { get; set; }
    }
}
