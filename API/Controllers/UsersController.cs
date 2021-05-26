using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase //ControllerBase : A base class for an MVC controller without view support.
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

//Below code is synchronous. What this means is that when we make a request that goes to our database, 
//then the thread that is currently handling this request is blocked until the db request fulfilled.

        // [HttpGet] //We specify the type of thing that we're going to return inside this
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // {
        //     return _context.Users.ToList();
        // }
        // //api/users/id
        // [HttpGet("{id}")] //We get an individual user by their ID.
        // public ActionResult<AppUser> GetUser(int id)
        // {
        //     return _context.Users.Find(id);
        // }
//The async keyword turns a method into an async method, which allows you to use the await keyword in its body.
// When the await keyword is applied, it suspends the calling method and yields control back to its caller 
//until the awaited task is complete. await can only be used inside an async method.

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           //When a request goes to the db,this code pauses/waits its deferred it to a task that
           //then goes and makes the query to the database.
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}