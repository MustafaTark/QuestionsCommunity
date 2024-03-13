﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(BusinessRuleValidationException))
            {
                var problemDetails = new ProblemDetails
                {
                    Type = "https://your-api-url/errors/business-rule-validation",
                    Title = "A business rule validation error occurred.",
                    Detail = context.Exception.Message,
                    Status = StatusCodes.Status400BadRequest
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.ExceptionHandled = true;
            }
        }
    }
}
