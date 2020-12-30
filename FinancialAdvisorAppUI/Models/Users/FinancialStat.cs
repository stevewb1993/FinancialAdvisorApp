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
        public FinancialStat(DateTime financeDate, string financeTypeId, FinanceType financeType)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceType = financeType;
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

        public FinancialStat(DateTime financeDate, string financeTypeId, decimal financeValue, decimal interestRate, string userId, string id)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceValue = financeValue;
            UserId = userId;
            Id = id;
            InterestRate = interestRate;
        }

        public DateTime FinanceDate { get; set; }
        public string FinanceTypeId { get; set; }
        [Required]
        public decimal FinanceValue { get; set; }
        public decimal InterestRate { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
