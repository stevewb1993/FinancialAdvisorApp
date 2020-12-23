using FinancialAdvisorAppAPI.Data.AspNet;
using System;
using System.Collections.Generic;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Users
{
    public partial class UserDetail
    {
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
