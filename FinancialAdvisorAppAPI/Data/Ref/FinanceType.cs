using FinancialAdvisorAppAPI.Contracts.Data;
using FinancialAdvisorAppAPI.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Ref
{
    [Table("FinanceTypes", Schema ="Ref")]
    public partial class FinanceType : ApplicationData
    {

        [Key] 
        public int Id { get; set; }
        public string FinanceDesc { get; set; }

        public virtual ICollection<FinancialStat> FinancialData { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}
