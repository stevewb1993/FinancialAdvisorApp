using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.DTOs.Users;
using FinancialAdvisorAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Controllers.Users
{
    /// <summary>
    /// Endpoint used to interact with the Authors in the book store's database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class GoalsController : Controller
    {

        private readonly IGoalRepository _goalRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public GoalsController(IGoalRepository goalRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _goalRepository = goalRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get financial goal by UserID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A users goals</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoalsByUserId(string userId)
        {
            var location = ControllerHelperFunctions.GetControllerActionNames(ControllerContext);
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                var goalList = await _goalRepository.FindAllByUserId(userId);
                if (goalList == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {userId}");
                    return NotFound();
                }

                var response = goalList.Select(x => _mapper.Map<GoalDTO>(x));  //_mapper.Map<GoalDTO>(goalList);
                _logger.LogInfo($"{location}: Successfully got record with id: {userId}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ControllerHelperFunctions.ReturnInternalError(e, ControllerContext, _logger);
            }
        }


    }
}
