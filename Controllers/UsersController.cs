using System.Diagnostics;
using System.Globalization;
using AutoMapper;
using DatabaseOperations.Data;
using DatabaseOperations.Models;
using DatabaseOperations.Models.Dto;
using DatabaseOperations.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseOperations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;


        public UsersController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllUsers()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var userList = await _context.Users.Include(c=>c.Department).ToListAsync();
            

            var responseModel = new ResponseModel<User>(userList, userList.Count)
            {
                TimeSpanCreateList = stopwatch.ElapsedMilliseconds,
            };

            stopwatch.Stop();
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
        

        User user = _mapper.Map<User>(userDto);


            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                var returnModel = new ResponseModel<User>(user, result);
                return Ok(returnModel);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("CreateRandomUsers")]
        public async Task<IActionResult> CreateRandomUser(int quantity, int qtdDep)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var users = new List<User>();
            for (int i = 0; i < quantity; i++)
            {
                users.Add(new User().GenerateRandomUser(qtdDep));
            }

            var timeSpanCreateList = stopwatch.ElapsedMilliseconds;

            await _context.Users.AddRangeAsync(users);
            var timeSpanContexts = stopwatch.ElapsedMilliseconds;

            var result = await _context.SaveChangesAsync();
            var timeSpanSave = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            
            if (result > 0)
            {
                var responseModel = new ResponseModel<User>(users, result)
                {
                   TimeSpanCreateList = timeSpanCreateList,
                   TimeSpanContexts = timeSpanContexts,
                   TimeSpanSave = timeSpanSave
                };
                return Ok(responseModel);
            }
            return BadRequest();

        }
    }
}
