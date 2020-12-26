using FinancialAdvisorAppUI.Contracts.Models;
using FinancialAdvisorAppUI.Models.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Models.Users
{
    public class UserDetail : ApplicationData
    {

        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }
    }
}
