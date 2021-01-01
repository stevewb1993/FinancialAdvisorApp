using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data.Ref;
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

        private readonly IFinanceTypeRepository _financeTypeRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly GenericControllerFunctions<FinanceType> _helperFunctions;

        public FinanceTypesController(IFinanceTypeRepository financeTypeRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _financeTypeRepository = financeTypeRepository;
            _logger = logger;
            _mapper = mapper;
            _helperFunctions = new GenericControllerFunctions<FinanceType>(_logger, _mapper, _financeTypeRepository);
        }

       
        /// <summary>
        /// get a finance type by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>a finance type</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFinanceTypeById(int Id)
        {
            return await _helperFunctions.GetRecordById<FinanceTypeDTO>(Id, ControllerContext);
        }


        /// <summary>
        /// get all finance types
        /// </summary>
        /// <param></param>
        /// <returns>a finance type</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFinanceTypes()
        {
            return await _helperFunctions.GetAllRecords<FinanceTypeDTO>(ControllerContext);
        }



        /// <summary>
        /// delete a finance type by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFinanceTypeById(int Id)
        {
            return await _helperFunctions.DeleteRecordById(Id, ControllerContext);
        }

        /// <summary>
        /// Update a finance type
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="financeTypeDTO"></param>
        /// <returns>A single finance type</returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFinanceTypeById(int Id, [FromBody] FinanceTypeDTO financeTypeDTO)
        {
            return await _helperFunctions.UpdateRecordById(Id, financeTypeDTO, ControllerContext);
        }

        /// <summary>
        /// Creates a Finance Type
        /// </summary>
        /// <param name="financeTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] FinanceTypeDTO financeTypeDTO)
        {
            return await _helperFunctions.Create(financeTypeDTO, ControllerContext);
        }

    }
}
