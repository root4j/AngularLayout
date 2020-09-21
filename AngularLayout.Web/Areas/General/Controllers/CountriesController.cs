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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryBusiness _Business;

        public CountriesController(ICountryBusiness Business)
        {
            _Business = Business;
        }

        // GET: General/api/Countries
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

        // GET: General/api/Countries/COL
        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            try
            {
                return Ok(_Business.FindById(id));
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: General/api/Countries
        [HttpPost]
        public IActionResult Post([FromBody] Country input)
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

        // PUT: General/api/Countries/COL-08001
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Country input)
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