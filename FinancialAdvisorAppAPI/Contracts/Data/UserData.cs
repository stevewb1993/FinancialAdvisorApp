using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Contracts.Data
{
    public abstract class UserData : ApplicationData
    {
        public IComparable UserId;
        
    }
}
