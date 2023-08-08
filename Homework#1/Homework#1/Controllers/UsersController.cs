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
        public ActionResult<string> GetById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index is a negative number.");
                }

                if (id >= StaticDb.UserNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The note with index {id} was not found.");
                }

                var usersnames = StaticDb.UserNames;
                return Ok(usersnames[(int)id]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Contact the support team");
            }
        }
    }
}
