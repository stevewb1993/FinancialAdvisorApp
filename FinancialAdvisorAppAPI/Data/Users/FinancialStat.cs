using FinancialAdvisorAppAPI.Contracts.Data;
using FinancialAdvisorAppAPI.Data.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("FinancialStats", Schema = "users")]
    public partial class FinancialStat : UserData
    {
        public DateTime FinanceDate { get; set; }
        public string FinanceTypeId { get; set; }
        public decimal FinanceValue { get; set; }
        public decimal InterestRate { get; set; }

        public virtual FinanceType FinanceType{ get; set; }
        public virtual UserDetail User { get; set; }
    }
}
