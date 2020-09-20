using AngularLayout.Model.Business.General;
using AngularLayout.Model.Common;
using AngularLayout.Model.Common.Exceptions;
using AngularLayout.Model.Common.Loggers;
using AngularLayout.Model.Entities.General;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AngularLayout.Web.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constants.AREA_GENERAL)]
    [EnableCors(Constants.APP_POLICY)]
    public class CitiesController : ControllerBase
    {
        private readonly ICityBusiness _Business;

        public CitiesController(ICityBusiness Business)
        {
            _Business = Business;
        }

        // GET: General/api/Cities
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_Business.GetAll());
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: General/api/Cities/COL-08
        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            try
            {
                return Ok(_Business.GetAllByStateCode(id));
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: General/api/Cities
        [HttpPost]
        public IActionResult Post([FromBody] City input)
        {
            try
            {
                _Business.Create(input);
                return Ok(input);
            }
            catch (EqualUniqueRowException ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status206PartialContent, ex.Message);
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: General/api/Cities/COL-08001
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] City input)
        {
            try
            {
                _Business.Update(id, input);
                return Ok(input);
            }
            catch (NonEqualObjectException ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status206PartialContent, ex.Message);
            }
            catch (NonObjectFoundException ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status207MultiStatus, ex.Message);
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}