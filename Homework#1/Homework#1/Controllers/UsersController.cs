using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetAll()
        {
            try
            {
                var usernames = StaticDb.UserNames;
                return Ok(usernames);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpGet("userId/{id}")]
        public ActionResult<string> GetById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No ID provided.");
                }

                if (id >= StaticDb.UserNames.Count || id < 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The username with index {id} was not found.");
                }

                var username = StaticDb.UserNames[(int)id];
                return Ok(username);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Contact the support team");
            }
        }
    }
}
