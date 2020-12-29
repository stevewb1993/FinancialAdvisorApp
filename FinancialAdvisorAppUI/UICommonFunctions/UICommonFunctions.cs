using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppUI.UICommonFunctions
{
    public static class UICommonFunctions
    {

        private static IToastService _toastService = new ToastService();

        public static void ReportSuccessOrFailure (bool successStatus)
        {
            if (successStatus)
            {
                _toastService.ShowSuccess("Details submitted successfully", "");
            }
            else
            {
                _toastService.ShowError("Something went wrong");
            }
        }
    }
}
