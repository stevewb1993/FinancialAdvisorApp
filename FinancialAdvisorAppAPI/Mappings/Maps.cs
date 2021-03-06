﻿using AutoMapper;
using FinancialAdvisorAppAPI.Data;
using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using FinancialAdvisorAppAPI.DTOs;
using FinancialAdvisorAppAPI.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Goal, GoalDTO>().ReverseMap();
            CreateMap<FinanceType, FinanceTypeDTO>().ReverseMap();
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
            CreateMap<FinancialStat, FinancialStatDTO>().ReverseMap();
        }
    }
}
