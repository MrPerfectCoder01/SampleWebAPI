using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICrud.Models.Data;

namespace WebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext context;

        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDetail>>> GetEmployee()
        {

            List<EmployeeDetail> res = await context.EmployeeDetails.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(long id)
        {
            EmployeeDetail employee = await context.EmployeeDetails.FindAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> AddEmployee(EmployeeDetail employee)
        {
            if (employee == null)
                return BadRequest();

            await context.EmployeeDetails.AddAsync(employee);

            await context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeById",new { id = employee.EmpId}, employee);            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDetail>> UpdateEmployee(int id, EmployeeDetail employee)
        {
            if (id != employee.EmpId)
                return BadRequest();

            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetail>> DeleteEmployee(long id)
        {
            if (id < 0)
                return BadRequest();

            EmployeeDetail employee = await context.EmployeeDetails.FindAsync(id);

            if (employee == null)
                return BadRequest();

            context.EmployeeDetails.Remove(employee);
            await context.SaveChangesAsync();

            return Ok(employee);

        }
    }
}
