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
    public class DepartmentsController : ControllerBase
    {

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentsController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAllDepartments()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var departments = await _context.Departments.ToListAsync();
            var responseModel = new ResponseModel<Department>(departments, departments.Count)
            {
                TimeSpanCreateList = stopwatch.ElapsedMilliseconds,
            };

            stopwatch.Stop();
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartments(DepartmentDto departmentDto)
        {
           var department = _mapper.Map<Department>(departmentDto);
            _context.Departments.Add(department);
            var result = await _context.SaveChangesAsync();
            var response = new ResponseModel<Department>(department, result);
            return Ok(response);
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
                departments.Add(new Department().GenerateRandomDepartment());
            }

            var timeSpanCreateList = stopwatch.ElapsedMilliseconds;
            await _context.Departments.AddRangeAsync(departments);
            var timeSpanContexts = stopwatch.ElapsedMilliseconds;

            var result = await _context.SaveChangesAsync();
            var timeSpanSave = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();



            if (result > 0)
            {
                var responseModel = new ResponseModel<Department>(departments, result)
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
