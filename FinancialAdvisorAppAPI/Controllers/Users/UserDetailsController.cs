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
    public class UserDetailsController : Controller
    {

        private readonly IUserDetailRepository _userDetailRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly GenericControllerFunctions<UserDetail> _helperFunctions;

        public UserDetailsController(IUserDetailRepository userDetailRepository,
            ILoggerService logger,
            IMapper mapper)
            {
            _userDetailRepository = userDetailRepository;
            _logger = logger;
            _mapper = mapper;
            _helperFunctions = new GenericControllerFunctions<UserDetail>(_logger, _mapper, _userDetailRepository);
        }


        /// <summary>
        /// get user details by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>a users details </returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserDetailById(string Id)
        {
            return await _helperFunctions.GetRecordById<UserDetailDTO>(Id, ControllerContext);
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
        public async Task<IActionResult> DeleteFinanceTypeById(string Id)
        {
            return await _helperFunctions.DeleteRecordById(Id, ControllerContext);
        }

        /// <summary>
        /// Update a user detail
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userDetailDTO"></param>
        /// <returns>A single user detail</returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFinanceTypeById(string Id, [FromBody] UserDetailDTO userDetailDTO)
        {
            return await _helperFunctions.UpdateRecordById(Id, userDetailDTO, ControllerContext);
        }

        /// <summary>
        /// Creates a user detail
        /// </summary>
        /// <param name="userDetailDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] UserDetailDTO userDetailDTO)
        {
            return await _helperFunctions.Create(userDetailDTO, ControllerContext);
        }

    }
}
