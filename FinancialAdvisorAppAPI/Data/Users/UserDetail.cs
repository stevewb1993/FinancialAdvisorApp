using FinancialAdvisorAppAPI.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("UserDetails", Schema = "users")]
    public partial class UserDetail : ApplicationData
    {
        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }

    }
}
