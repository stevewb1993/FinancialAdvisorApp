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
    public class GenericControllerFunctions<T> : Controller where T : ApplicationData
    {
        public readonly ILoggerService _logger;
        public readonly IMapper _mapper;
        public readonly IRepositoryBase<T> _repositoryBase;

        public GenericControllerFunctions(ILoggerService logger, IMapper mapper, IRepositoryBase<T> repositoryBase)
        {
            _logger = logger;
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }

        ////////
        //section for handling API calls
        ////////
        
        
        //Gets
        public async Task<IActionResult> GetRecordById<dto>(string Id, ControllerContext controllerContext) where dto : DTOBase
        {

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

                var response = _mapper.Map<dto>(recordList);
                _logger.LogInfo($"{location}: Successfully got record with id: {Id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ReturnInternalError(e, controllerContext);
            }
        }

        public async Task<IActionResult> GetAllRecords<dto>(ControllerContext controllerContext) where dto : DTOBase
        {
            string location = GetControllerActionNames(controllerContext);
            try
            {
                _logger.LogInfo($"{location}: Attempted Call all records");
                var recordList = await _repositoryBase.FindAll();
                if (recordList == null || recordList.Count == 0)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve records");
                    return NotFound();
                }

                var response = _mapper.Map<IList<dto>>(recordList);
                _logger.LogInfo($"{location}: Successfully got all records");
                return Ok(response);
            }
            catch (Exception e)
            {
                return ReturnInternalError(e, controllerContext);
            }
        }

        //Posts / Creates
        public async Task<IActionResult> Create([FromBody] DTOBase Dto, ControllerContext controllerContext)
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


        //Puts / Updates

        public async Task<IActionResult> UpdateRecordById(string Id, DTOBase dto, ControllerContext controllerContext)
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



        //Deletes
        public async Task<IActionResult> DeleteRecordById(string id, ControllerContext controllerContext)
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



        //section for helper functions
        public string GetControllerActionNames(ControllerContext controllerContext)
        {
            var controller = controllerContext.ActionDescriptor.ControllerName;
            var action = controllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        public IActionResult ReturnInternalError(string message)
        {
            _logger.LogError(message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public IActionResult ReturnInternalError(Exception e, ControllerContext controllerContext)
        {
            var location = GetControllerActionNames(controllerContext);
            string message = $"{location}: {e.Message} - {e.InnerException}";
            _logger.LogError(message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
}
