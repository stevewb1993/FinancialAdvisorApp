using System.Collections.Generic;

namespace FinancialAdvisorAppAPI.DTOs.Users
{
    public class FinanceTypeDTO : DTOBase
    {
        public string FinanceDesc { get; set; }
        public string StockOrFlow { get; set; }
        public string Category { get; set; }
        public string Liquidity { get; set; }
    }
}