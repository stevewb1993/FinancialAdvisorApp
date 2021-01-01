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
        public FinanceType(int id, string financeDesc, string stockOrFlow)
        {
            FinanceDesc = financeDesc;
            Id = id;
            StockOrFlow = stockOrFlow;
            Category = category;
        }

        public string FinanceDesc { get; set; }
        public string StockOrFlow { get; set; }
        public string Liquidity { get; set; }
        public string Category { get; set; }
    }
}
