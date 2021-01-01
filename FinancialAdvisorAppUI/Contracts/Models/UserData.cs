using FinancialAdvisorAppUI.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Contracts.Models
{
    public class UserData : ApplicationData
    {
        
        public int UserId { get; set; }
        
    }
}
