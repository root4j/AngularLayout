using AngularLayout.Model.Business.General;
using AngularLayout.Model.Common;
using AngularLayout.Model.Common.Exceptions;
using AngularLayout.Model.Common.Loggers;
using AngularLayout.Model.Entities.General;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularLayout.Web.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constants.AREA_GENERAL)]
    [EnableCors(Constants.APP_POLICY)]
    public class ValueListsController : ControllerBase
    {
        private readonly IValueListBusiness _Business;

        public ValueListsController(IValueListBusiness Business)
        {
            _Business = Business;
        }

        // GET: General/api/ValueLists
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

        // GET: General/api/ValueLists/Gex-Sex
        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            try
            {
                return Ok(_Business.GetAllByCategory(id));
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: General/api/ValueLists
        [HttpPost]
        public IActionResult Post([FromBody] ValueList input)
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

        // PUT: General/api/ValueLists/Gen-Sex-Male
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ValueList input)
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
