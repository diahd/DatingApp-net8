using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController(DataContext context) : BaseApiController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            //error 401 unauthorized
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            //404 not found
            var thing = context.Users.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            //kode 500 Internal server error
            var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing has happened");
            
            return thing;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            //400 bad req
            return BadRequest("This is a bad request");
        }
    }
}
