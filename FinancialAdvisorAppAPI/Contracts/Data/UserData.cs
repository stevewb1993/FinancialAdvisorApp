using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts.Data
{
    public class UserData : ApplicationData
    {
        
        public string UserId { get; set; }
        
    }
}
