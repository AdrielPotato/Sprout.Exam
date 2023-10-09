using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Common.Models;
using Sprout.Exam.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Functions
{
    public static class HandleControllerActions
    {
        public static async Task<JsonResult> Execute<T>(BaseController controller, IRequest<Result<T>> request)
        {
            var result = await controller._mediator.Send(request);

            return HandleResponse.Execute(result, controller);
        }
    }
}
