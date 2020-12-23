using FinancialAdvisorAppAPI.Data.AspNet;
using FinancialAdvisorAppAPI.Data.Ref;
using System;
using System.Collections.Generic;


namespace FinancialAdvisorAppAPI.Data.Users
{
    public partial class FinancialStat
    {
        public int FinanceId { get; set; }
        public string UserId { get; set; }
        public DateTime FinanceDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal FinanceValue { get; set; }

        public virtual FinanceType FinanceType{ get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
