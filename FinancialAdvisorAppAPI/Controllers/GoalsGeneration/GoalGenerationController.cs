using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data.Ref;
using FinancialAdvisorAppAPI.Data.Users;
using FinancialAdvisorAppAPI.DTOs.Users;
using FinancialAdvisorAppAPI.Services.GoalGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAdvisorAppAPI.Controllers.GoalsGeneration
{
    /// <summary>
    /// Endpoint used to interact with the Authors in the book store's database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class GoalGenerationController : Controller
    {

        private readonly IFinancialStatRepository _financialStatRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IFinanceTypeRepository _financeTypeRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly GenericUserControllerFunctions<FinancialStat> _financialStatHelperFunctions;
        private readonly GenericControllerFunctions<UserDetail> _userDetailHelperFunctions;
        private readonly GenericControllerFunctions<FinanceType> _financeTypeHelperFunctions;

        public GoalGenerationController(IFinancialStatRepository financialStatRepository,
            IUserDetailRepository userDetailRepository,
            IFinanceTypeRepository financeTypeRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _financialStatRepository = financialStatRepository;
            _financeTypeRepository = financeTypeRepository;
            _logger = logger;
            _mapper = mapper;
            _financialStatHelperFunctions = new GenericUserControllerFunctions<FinancialStat>(_logger, _mapper, _financialStatRepository);
            _userDetailHelperFunctions = new GenericControllerFunctions<UserDetail>(_logger, _mapper, _userDetailRepository);
            _financeTypeHelperFunctions = new GenericControllerFunctions<FinanceType>(_logger, _mapper, _financeTypeRepository);
        }


        /// <summary>
        /// Generate goals based on UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A set of system generated goals</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenerateGoalsByUserId(string userId)
        {

            //get user financialstats
            string location = _financialStatHelperFunctions.GetControllerActionNames(ControllerContext);
            UserDetail userDetail = new UserDetail();
            IList<FinancialStat> financialStatList = new List<FinancialStat>();
            IList<FinanceType> financeTypeList = new List<FinanceType>();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                financialStatList = await _financialStatRepository.FindAllByUserId(userId);

                if (financialStatList == null || financialStatList.Count == 0)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {userId}");
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return _financialStatHelperFunctions.ReturnInternalError(e, ControllerContext);
            }

            //get user details
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                userDetail = await _userDetailRepository.FindById(userId);

                if (userDetail == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {userId}");
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return _financialStatHelperFunctions.ReturnInternalError(e, ControllerContext);
            }

            //get finance type list
            try
            {
                financeTypeList = await _financeTypeRepository.FindAll();
            }
            catch (Exception e)
            {
                return _financialStatHelperFunctions.ReturnInternalError(e, ControllerContext);
            }

            //Generate new goals
            List<Goal> generatedGoals = GoalGenerator.GenerateGoals(userDetail, financialStatList, financeTypeList);
            return Ok(generatedGoals);

        }




    }
}
