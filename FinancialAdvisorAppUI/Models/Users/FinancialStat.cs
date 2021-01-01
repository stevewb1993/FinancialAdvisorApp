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
        public FinancialStat(DateTime financeDate, int financeTypeId, FinanceType financeType)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceType = financeType;
        }

        /// <summary>
        /// This construcor initializes the fin stat with some holding values. Only to be used with the create fin stat user page
        /// </summary>
        /// <param name="financeDate"></param>
        /// <param name="userId"></param>
        /// <param name="financeType"></param>
        /// <param name="financeTypeId"></param>
        public FinancialStat(DateTime financeDate, int userId)
        {
            FinanceDate = financeDate;
            UserId = userId;
            Id = null;
        }

        public FinancialStat()
        {
        }

        public FinancialStat(DateTime financeDate, int financeTypeId, decimal financeValue, int userId)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceValue = financeValue;
            UserId = userId;
        }

        public FinancialStat(DateTime financeDate, int financeTypeId, decimal financeValue, decimal interestRate, int userId)
        {
            FinanceDate = financeDate;
            FinanceTypeId = financeTypeId;
            FinanceValue = financeValue;
            UserId = userId;
            InterestRate = interestRate;
        }

        public DateTime FinanceDate { get; set; }
        public int? FinanceTypeId { get; set; }
        public string FinanceDesc { get; set; }
        [Required]
        public decimal FinanceValue { get; set; }
        public decimal InterestRate { get; set; }
        public string UserFriendlyName { get; set; }

        public virtual FinanceType FinanceType { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
