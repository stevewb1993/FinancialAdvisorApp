using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Contracts.Data;
using FinancialAdvisorAppAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Controllers
{
    public class GenericUserControllerFunctions<T> : GenericControllerFunctions<T> where T : UserData
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepositoryBase<T> _repositoryBase;
        private readonly ControllerContext _calledControllerContext;

        public GenericUserControllerFunctions(ILoggerService logger, IMapper mapper, IUserRepositoryBase<T> repositoryBase, ControllerContext calledControllerContext) : base(logger, mapper, repositoryBase, calledControllerContext)
        {

        }

        public async Task<IActionResult> GetRecordsByUserId<dto>(string userId) where dto : DTOBase
        {
            string location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                var recordList = await _repositoryBase.FindAllByUserId(userId);
                if (recordList == null || recordList.Count == 0)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {userId}");
                    return NotFound();
                }

                var response = _mapper.Map<IList<dto>>(recordList);
                _logger.LogInfo($"{location}: Successfully got record with id: {userId}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ReturnInternalError(e);
            }
        }

    }
}
