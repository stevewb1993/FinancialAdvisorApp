using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.DTOs.Users
{
    public class FinancialStatDTO : DTOBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime FinanceDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal FinanceValue { get; set; }

        public virtual FinanceTypeDTO FinanceType { get; set; }
        public virtual UserDetailDTO User { get; set; }
    }
}
