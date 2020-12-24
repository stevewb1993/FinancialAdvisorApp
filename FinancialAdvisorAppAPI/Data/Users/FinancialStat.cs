using FinancialAdvisorAppAPI.Data.AspNet;
using FinancialAdvisorAppAPI.Data.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("FinancialStats", Schema = "users")]
    public partial class FinancialStat
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime FinanceDate { get; set; }
        public int FinanceTypeId { get; set; }
        public decimal FinanceValue { get; set; }

        public virtual FinanceType FinanceType{ get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
