using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts.Data
{
    public class ApplicationData
    {
        [Key]
        public int Id { get; set; }
    }
}
