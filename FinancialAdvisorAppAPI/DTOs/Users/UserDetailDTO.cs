using System;

namespace FinancialAdvisorAppAPI.DTOs.Users
{
    public class UserDetailDTO : DTOBase
    {
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }

    }
}