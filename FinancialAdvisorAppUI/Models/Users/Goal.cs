﻿using FinancialAdvisorAppUI.Models.Ref;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.Models.Users
{
    public class Goal
    {

        [DisplayName("Due Name")]
        public DateTime DueDate { get; set; }
        public string FinanceTypeId { get; set; }
        [DisplayName("Goal Value")]
        public decimal GoalValue { get; set; }
        [DisplayName("Goal Start Date")]
        public DateTime GoalStartDate { get; set; }
        [DisplayName("Type of goal")]
        public virtual FinanceType FinanceType { get; set; }
    }
}
