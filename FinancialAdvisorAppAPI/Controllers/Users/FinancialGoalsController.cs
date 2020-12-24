using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
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
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class FinancialGoalsController : Controller
    {

        private readonly IFinancialGoalRepository _financialGoalRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public FinancialGoalsController(IFinancialGoalRepository financialGoalRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _financialGoalRepository = financialGoalRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get financial goal by UserID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Author's record</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFinancialGoals(string userId)
        {
            var location = ControllerHelperFunctions.GetControllerActionNames(ControllerContext);
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                var author = await _financialGoalRepository.FindById(id);
                if (author == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<AuthorDTO>(author);
                _logger.LogInfo($"{location}: Successfully got record with id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ControllerHelperFunctions.ReturnInternalError(e, ControllerContext, _logger);
            }
        }


    }
}
