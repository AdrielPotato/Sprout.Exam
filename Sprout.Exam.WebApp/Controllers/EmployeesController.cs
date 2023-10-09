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
            // var result = await Task.FromResult(StaticEmployees.ResultList);
            //var query = new GetAllEmployeesQuery();
            //var result = await _mediator.Send(query);
            //return Ok(result);
            return await HandleControllerActions.Execute(this, new GetAllEmployeesQuery());
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == id));
            //return Ok(result);

            return await HandleControllerActions.Execute(this, new GetEmployeeByIdQuery() { Id = id });
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateEmployeeCommand input)
        {
            //var item = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == input.Id));
            //if (item == null) return NotFound();
            //item.FullName = input.FullName;
            //item.Tin = input.Tin;
            //item.Birthdate = input.Birthdate.ToString("yyyy-MM-dd");
            //item.TypeId = input.TypeId;
            //return Ok(item);

            return await HandleControllerActions.Execute(this, input);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand input)
        {

            //var id = await Task.FromResult(StaticEmployees.ResultList.Max(m => m.Id) + 1);
            //StaticEmployees.ResultList.Add(new EmployeeDto
            //{
            //    Birthdate = input.Birthdate.ToString("yyyy-MM-dd"),
            //    FullName = input.FullName,
            //    Id = id,
            //    Tin = input.Tin,
            //    TypeId = input.TypeId
            //});


            //return Created($"/api/employees/{id}", id);

            //var command = new CreateEmployeeCommand()
            //{
            //    Birthdate = input.Birthdate.ToString("yyyy-MM-dd"),
            //    FullName = input.FullName,
            //    Tin = input.Tin,
            //    TypeId = input.TypeId
            //};
            //var result = await _mediator.Send(command);
            //return Created($"/api/employees/{result.ID}", result.ID);

            return await HandleControllerActions.Execute(this, input);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == id));
            //if (result == null) return NotFound();
            //StaticEmployees.ResultList.RemoveAll(m => m.Id == id);
            //return Ok(id);

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
            //var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == input.Id));

            //if (result == null) return NotFound();
            //var type = (EmployeeType)result.TypeId;
            //var employee = _employeeFactory.CreateEmployee(type, input.AbsentDays, input.WorkedDays);
            //var result = await _mediator.Send(input);
            return await HandleControllerActions.Execute(this, input);


        }

    }
}
