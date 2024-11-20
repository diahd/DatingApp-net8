using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class UsersController(DataContext context) : BaseApiController
    {
        //private readonly DataContext context = context;

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            var users = await context.Users.ToListAsync();

            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.Where(x => x.Id == id).ToListAsync();

            if (user.Count < 1) return NotFound();

            /*
             * or u can use this
             * var user = context.Users.Find(id);
             * if (user == null) return NotFound();
             */

            return Ok(user);
        }
    }
}
