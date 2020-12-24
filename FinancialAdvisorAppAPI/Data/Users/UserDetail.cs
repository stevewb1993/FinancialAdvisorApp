using FinancialAdvisorAppAPI.Data.AspNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialAdvisorAppAPI.Data.Users
{
    [Table("UserDetails", Schema = "users")]
    public partial class UserDetail
    {
        [Key]
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
