using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.Commands.CalculateEmployeeSalary;
using Sprout.Exam.Business.Commands.CreateEmployee;
using Sprout.Exam.Business.Commands.DeleteEmployee;
using Sprout.Exam.Business.Commands.UpdateEmployee;
using Sprout.Exam.Business.Queries.GetAllEmployees;
using Sprout.Exam.Business.Queries.GetEmployeeById;
using Sprout.Exam.WebApp.Functions;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {

        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }


        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await HandleControllerActions.Execute(this, new GetAllEmployeesQuery());
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await HandleControllerActions.Execute(this, new GetEmployeeByIdQuery() { Id = id });
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateEmployeeCommand input)
        {
            return await HandleControllerActions.Execute(this, input);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand input)
        {
            return await HandleControllerActions.Execute(this, input);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await HandleControllerActions.Execute(this, new DeleteEmployeeCommand() { Id = id });
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(CalculateEmployeeSalaryCommand input)
        {
            return await HandleControllerActions.Execute(this, input);


        }

    }
}
