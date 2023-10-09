using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public ValidateModelStateAttribute()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                //        .SelectMany(v => v.Errors)
                //        .Select(v => v.ErrorMessage)
                //        .ToList();

                //var responseObj = new
                //{
                //    Message = "Bad Request",
                //    Errors = errors
                //};

                //context.Result = new JsonResult(responseObj)
                //{
                //    StatusCode = 400
                //};

                HandleInvalidModelStateException(context);
            }
        }

        private void HandleInvalidModelStateException(ActionExecutingContext context)
        {
            var errors = context.ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Invalid Request",
                Errors = errors
            };

            context.Result = new BadRequestObjectResult(response);
        }
    }
}
