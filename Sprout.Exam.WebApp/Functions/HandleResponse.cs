using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Common.Models;
using Sprout.Exam.WebApp.Controllers;
using System.Collections.Generic;

namespace Sprout.Exam.WebApp.Functions
{
    public static class HandleResponse
    {
        public static JsonResult Execute<T>(Result<T> result, BaseController controller)
        {
            if (result.Success == false)
            {
                controller.Response.StatusCode = result.StatusCode;

                return new JsonResult(new Response<List<string>>
                {
                    Success = false,
                    StatusCode = result.StatusCode,
                    Message = result.Message,
                    Errors = result.Errors ?? new List<string>()
                });
            }
            else
            {
                return new JsonResult(new Response<T>
                {
                    Success = true,
                    StatusCode = result.StatusCode == 0 ? 200 : result.StatusCode,
                    Message = "OK",
                    Payload = result.Payload,
                    Errors = new List<string>()
                });
            }
        }
    }
}
