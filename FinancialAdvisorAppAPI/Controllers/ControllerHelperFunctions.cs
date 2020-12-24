using FinancialAdvisorAppAPI.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Controllers
{
    public static class ControllerHelperFunctions
    {
        public static string GetControllerActionNames(ControllerContext controllerContext)
        {
            var controller = controllerContext.ActionDescriptor.ControllerName;
            var action = controllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        public static IActionResult ReturnInternalError(string message, ILoggerService logger)
        {
            logger.LogError(message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public static IActionResult ReturnInternalError(Exception e, ControllerContext controllerContext, ILoggerService logger)
        {
            var location = GetControllerActionNames(controllerContext);
            string message = $"{location}: {e.Message} - {e.InnerException}";
            logger.LogError(message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
}
