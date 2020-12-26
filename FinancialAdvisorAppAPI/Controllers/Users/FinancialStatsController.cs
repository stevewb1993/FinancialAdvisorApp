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
    public class FinancialStatsController : Controller
    {

        private readonly IFinancialStatRepository _financialStatRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly GenericUserControllerFunctions<FinancialStat> _helperFunctions;

        public FinancialStatsController(IFinancialStatRepository financialStatRepository, ILoggerService logger, IMapper mapper, GenericUserControllerFunctions<FinancialStat> helperFunctions)
        {
            _financialStatRepository = financialStatRepository;
            _logger = logger;
            _mapper = mapper;
            _helperFunctions = helperFunctions;
        }



        /// <summary>
        /// Get financial stat by UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A users financial stats</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFinancialStatByUserId(string userId)
        {
            return await _helperFunctions.GetRecordsByUserId<FinancialStatDTO>(userId, ControllerContext);
        }

        ///// <summary>
        ///// Get financial stat by ID
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns>A single financial stat</returns>
        //[HttpGet("{Id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetFinancialStatById(string Id)
        //{
        //    return await _helperFunctions.GetRecordById<FinancialStatDTO>(Id);
        //}

        /// <summary>
        /// Delete a financial stat by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFinancialStatById(string Id)
        {
            return await _helperFunctions.DeleteRecordById(Id, ControllerContext);
        }

        /// <summary>
        /// Update a financial goal
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="financialStatDTO"></param>
        /// <returns>A single goals</returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFinancialStatById(string Id, [FromBody] FinancialStatDTO financialStatDTO)
        {
            return await _helperFunctions.UpdateRecordById(Id, financialStatDTO, ControllerContext);
        }

        /// <summary>
        /// Creates a financial stat
        /// </summary>
        /// <param name="financialStatDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] FinancialStatDTO financialStatDTO)
        {
            return await _helperFunctions.Create(financialStatDTO, ControllerContext);
        }


    }
}
