using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinancialAdvisorAppAPI.Contracts;
using FinancialAdvisorAppAPI.Data.Users;
using FinancialAdvisorAppAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace FinancialAdvisorAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerService _logger;
        private readonly IConfiguration _config;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly GenericControllerFunctions<UserDetail> _userDetailHelperFunctions;
        private readonly IMapper _mapper;

        public UsersController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ILoggerService logger,
            IConfiguration config,
            IUserDetailRepository userDetailRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _config = config;
            _userDetailRepository = userDetailRepository;
            _userDetailHelperFunctions = new GenericControllerFunctions<UserDetail>(_logger, _mapper, _userDetailRepository);
        }
        /// <summary>
        /// USer Registration Endpoint
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                var username = userDTO.EmailAddress;
                var password = userDTO.Password;
                _logger.LogInfo($"{location}: Registration Attempt for {username} ");
                var user = new IdentityUser { Email = username, UserName = username };
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        _logger.LogError($"{location}: {error.Code} {error.Description}");
                    }
                    return InternalError($"{location}: {username} User Registration Attempt Failed");
                }
                await _userManager.AddToRoleAsync(user, "Customer");

                //create record for the user in the user details table
                var userDetail = new UserDetail(user.Id);
                await _userDetailRepository.Create(userDetail);

                return Created("login",new { result.Succeeded });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        /// <summary>
        /// User Login Endpoint
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                var username = userDTO.EmailAddress;
                var password = userDTO.Password;
                _logger.LogInfo($"{location}: Login Attempt from user {username} ");
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if (result.Succeeded)
                {
                    _logger.LogInfo($"{location}: {username} Successfully Authenticated");
                    var user = await _userManager.FindByEmailAsync(username);
                    _logger.LogInfo($"{location}: Generating Token");
                    var tokenString = await GenerateJSONWebToken(user);
                    return Ok(new { token = tokenString });
                }
                _logger.LogInfo($"{location}: {username} Not Authenticated");
                return Unauthorized(userDTO);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        private async Task<string> GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            //get the users integer user id and add to their claims
            var friendlyUserId = _userDetailRepository.FindByUserGuid(user.Id);
            Claim friendlyIdClaim = new Claim("FriendlyUserId", friendlyUserId.Id.ToString());
            claims.Add(friendlyIdClaim);

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                , _config["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}