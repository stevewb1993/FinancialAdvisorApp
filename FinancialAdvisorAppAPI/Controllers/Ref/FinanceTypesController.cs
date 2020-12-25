using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data.Users;
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
    public class FinanceTypesController : Controller
    {

        private readonly IGoalRepository _goalRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly GenericUserControllerFunctions<Goal> _helperFunctions;

        public FinanceTypesController(IGoalRepository goalRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _goalRepository = goalRepository;
            _logger = logger;
            _mapper = mapper;
            _helperFunctions = new GenericUserControllerFunctions<Goal>(_logger, _mapper, _goalRepository, ControllerContext);
        }

        /// <summary>
        /// Get financial goal by UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A users goals</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoalsByUserId(string userId)
        {
            return await _helperFunctions.GetRecordsByUserId<GoalDTO>(userId);
        }

        /// <summary>
        /// get a financial goal by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>a users goal </returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoalById(string Id)
        {
            return await _helperFunctions.GetRecordById<GoalDTO>(Id);
        }

        /// <summary>
        /// delete a goal by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGoalById(string Id)
        {
            return await _helperFunctions.DeleteRecordById(Id);
        }

        /// <summary>
        /// Update a goal
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="goalDTO"></param>
        /// <returns>A single goals</returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGoalById(string Id, [FromBody] GoalDTO goalDTO)
        {
            return await _helperFunctions.UpdateRecordById(Id, goalDTO);
        }

        /// <summary>
        /// Creates a goal
        /// </summary>
        /// <param name="goalDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] GoalDTO goalDTO)
        {
            return await _helperFunctions.Create(goalDTO);
        }

    }
}
