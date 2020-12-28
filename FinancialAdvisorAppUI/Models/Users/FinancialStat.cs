using FinancialAdvisorAppUI.Contracts.Models;
using FinancialAdvisorAppUI.Models.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Models.Users
{
    public class FinancialStat : UserData
    {
        public FinancialStat(DateTime financeDate, string financeTypeId)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
        }

        public FinancialStat()
        {
        }

        public FinancialStat(DateTime financeDate, string financeTypeId, decimal financeValue, string userId, string id)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceValue = financeValue;
            UserId = userId;
            Id = id;
        }

        public DateTime FinanceDate { get; set; }
        public string FinanceTypeId { get; set; }
        [Required]
        public decimal FinanceValue { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
