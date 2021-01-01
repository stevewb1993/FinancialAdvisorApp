using System;

namespace FinancialAdvisorAppAPI.DTOs.Users
{
    public class UserDetailDTO : DTOBase
    {
        public DateTime DateOfBirth { get; set; }
        public string HighestEducation { get; set; }
        public int RetirementAge { get; set; }
        public string UserGuid { get; set; }

    }
}