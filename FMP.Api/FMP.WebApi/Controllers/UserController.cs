using FMP.Database.Database.Contexts;
using FMP.Database.Database.Models;
using FMP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<PharmacyController> _logger;
        private readonly FindMyPharmacyDbContext _dbContext;

        public UserController(ILogger<PharmacyController> logger,
            FindMyPharmacyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserData>> Login(LogInRequest request)
        {
            var userQuery = from u in _dbContext.Users
                            where u.Email== request.Username && u.Password== request.Password
                            select u;

            var user = await userQuery.FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            var userData = new UserData
            {
                Id = user.Id, 
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email
            };

            return Ok(userData);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password
            };

            await _dbContext.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return Ok(new UserData
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email
            });
        }
    }
}
