using System.Diagnostics;
using System.Globalization;
using DatabaseOperations.Data;
using DatabaseOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseOperations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly MyDbContext _context;


        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> FindAllUsers()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var userList = await _context.Users.ToListAsync();
            var responseModel = new ResponseModel(userList, userList.Count)
            {
                TimeSpanCreateList = stopwatch.ElapsedMilliseconds,
            };

            stopwatch.Stop();
            return Ok(responseModel);
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            User user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Age = userDto.Age,
                Height = userDto.Height,
                NumberDecimal = userDto.Number,
                NumberDouble = Decimal.ToDouble(userDto.Number),
                NumberFloat = (float)Decimal.ToDouble(userDto.Number),
                DepartmentId = userDto.DepartmentId,
            };

            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                var returnModel = new ResponseModel(new List<User>() { user }, result);
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
                users.Add(new User(qtdDep));
            }

            var timeSpanCreateList = stopwatch.ElapsedMilliseconds;

            await _context.Users.AddRangeAsync(users);
            var timeSpanContexts = stopwatch.ElapsedMilliseconds;

            var result = await _context.SaveChangesAsync();
            var timeSpanSave = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();

            

            if (result > 0)
            {
                var responseModel = new ResponseModel(users, result)
                {
                   TimeSpanCreateList = timeSpanCreateList,
                   TimeSpanContexts = timeSpanContexts,
                   TimeSpanSave = timeSpanSave
                };
                return Ok(responseModel);
            }
            return BadRequest();

        }


        [HttpGet]
        [Route("Departments")]
        public async Task<IActionResult> FindAllDepartments()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var departments = await _context.Departments.ToListAsync();
            var responseModel = new ResponseModel(departments, departments.Count)
            {
                TimeSpanCreateList = stopwatch.ElapsedMilliseconds,
            };

            stopwatch.Stop();
            return Ok(responseModel);
        }

        [HttpPost]
        [Route("Departments")]
        public async Task<IActionResult> CreateDepartments(Department department)
        {
            _context.Departments.Add(department);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateRandomDepartments")]
        public async Task<IActionResult> CreateRandomDepartments(int quantity)
        {
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var departments = new List<Department>();
            for (int i = 0; i < quantity; i++)
            {
                departments.Add(new Department());
            }

            var timeSpanCreateList = stopwatch.ElapsedMilliseconds;
            await _context.Departments.AddRangeAsync(departments);
            var timeSpanContexts = stopwatch.ElapsedMilliseconds;

            var result = await _context.SaveChangesAsync();
            var timeSpanSave = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();



            if (result > 0)
            {
                var responseModel = new ResponseModel(departments, result)
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
