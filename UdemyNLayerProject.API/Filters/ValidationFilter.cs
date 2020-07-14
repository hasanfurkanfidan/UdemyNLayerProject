﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.Dtos;

namespace UdemyNLayerProject.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable < ModelError >modelErrors = context.ModelState.Values.SelectMany(p => p.Errors);
                modelErrors.ToList().ForEach(x =>
                errorDto.Errors.Add(x.ErrorMessage)
                );
                context.Result = new BadRequestObjectResult(errorDto);
            };
        }
    }
}