using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    [Authorize]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController //DataContext context
    {
        //private readonly DataContext context = context;

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers() 
        {
            //1.var users = await context.Users.ToListAsync();

            //2. var users = await userRepository.GetUsersAsync();
            //var usersToReturn = mapper.Map<IEnumerable<MemberDTO>>(users);

            //3.
            var users = await userRepository.GetMembersAsync();

            return Ok(users);
        }

        //[Authorize]
        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<AppUser>> GetUser(int id)
        //{
        //    var user = await context.Users.Where(x => x.Id == id).ToListAsync();

        //    if (user.Count < 1) return NotFound();

        //    /*
        //     * or u can use this
        //     * var user = context.Users.Find(id);
        //     * if (user == null) return NotFound();
        //     */

        //    return Ok(user);
        //}
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            //1.
            //var user = await userRepository.GetUserByUsernameAsync(username);
            //var userToReturn = mapper.Map<MemberDTO>(user);

            //2.
            var user = await userRepository.GetMemberAsync(username);

            if (user == null) return NotFound();

            /*
             * or u can use this
             * var user = context.Users.Find(id);
             * if (user == null) return NotFound();
             */

            return user;
        }
    }
}
