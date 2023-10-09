﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sprout.Exam.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
