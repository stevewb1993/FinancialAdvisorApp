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

        private readonly IUserRepositoryBase<T> _userRepositoryBase;

        public GenericUserControllerFunctions(ILoggerService logger, IMapper mapper, IUserRepositoryBase<T> repositoryBase) : base(logger, mapper, repositoryBase)
        {

            _userRepositoryBase = repositoryBase;
        }

        public async Task<IActionResult> GetRecordsByUserId<dto>(int userId, ControllerContext controllerContext) where dto : DTOBase
        {
            
            int actualUserId = GetUserIdFromClaims(controllerContext);
            if(actualUserId != userId) return BadRequest("user does not have claims for this request");
            
            
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {userId}");
                var recordList = await _userRepositoryBase.FindAllByUserId(userId);
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
                return ReturnInternalError(e, controllerContext);
            }
        }

        public override async Task<IActionResult> GetRecordById<dto>(int Id, ControllerContext controllerContext)
        {
            int actualUserId = GetUserIdFromClaims(controllerContext);
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {Id}");
                var recordList = await _repositoryBase.FindById(Id);
                if (recordList == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {Id}");
                    return NotFound();
                }

                if (!(this.validateUserId(recordList, controllerContext))) return BadRequest("user does not have claims for this request");

                var response = _mapper.Map<dto>(recordList);
                _logger.LogInfo($"{location}: Successfully got record with id: {Id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ReturnInternalError(e, controllerContext);
            }
        }

        public override async Task<IActionResult> Create([FromBody] DTOBase Dto, ControllerContext controllerContext)
        {
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (Dto == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var entity = _mapper.Map<T>(Dto);

                if (!(this.validateUserId(entity, controllerContext))) return BadRequest("user does not have claims for this request");

                var isSuccess = await _repositoryBase.Create(entity);
                if (!isSuccess)
                {
                    return ReturnInternalError($"{location}: Creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { entity });
            }
            catch (Exception e)
            {
                return ReturnInternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        public async override Task<IActionResult> UpdateRecordById(int Id, DTOBase dto, ControllerContext controllerContext)
        {
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Update Attempted on record with id: {Id} ");
                if (dto == null || Id != dto.Id || !ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Update failed with bad data - id: {Id}");
                    return BadRequest();
                }
                var isExists = await _repositoryBase.isExists(Id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {Id}");
                    return NotFound();
                }
                var entity = _mapper.Map<T>(dto);

                if (!(this.validateUserId(entity, controllerContext))) return BadRequest("user does not have claims for this request");

                var isSuccess = await _repositoryBase.Update(entity);
                if (!isSuccess)
                {
                    return ReturnInternalError($"{location}: Update failed for record with id: {Id}");
                }
                _logger.LogInfo($"{location}: Record with id: {Id} successfully updated");
                return NoContent();
            }
            catch (Exception e)
            {
                return ReturnInternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> DeleteRecordById(int id, ControllerContext controllerContext)
        {
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Delete Attempted on record with id: {id} ");

                var isExists = await _repositoryBase.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var entity = await _repositoryBase.FindById(id);


                if (!(this.validateUserId(entity, controllerContext))) return BadRequest("user does not have claims for this request");

                var isSuccess = await _repositoryBase.Delete(entity);
                if (!isSuccess)
                {
                    return ReturnInternalError($"{location}: Delete failed for record with id: {id}");
                }
                _logger.LogInfo($"{location}: Record with id: {id} successfully deleted");
                return NoContent();
            }
            catch (Exception e)
            {
                return ReturnInternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        private bool validateUserId(T entity, ControllerContext controllerContext)
        {
            try
            {
                string location = GetControllerActionNames(controllerContext);
                int actualUserId = GetUserIdFromClaims(controllerContext);
                int recordUserId = entity.UserId;
                if (actualUserId != recordUserId)
                {
                    _logger.LogWarn($"{location}: Request did not match id of user who made requst: {actualUserId}");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
