using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UdemyNLayerProject.Core.Service;
using UdemyNLayerProject.Web.Controllers;
using UdemyNLayerProject.Web.Dtos;

namespace UdemyNLayerProject.Web.Filters
{
    
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _productService;
        public NotFoundFilter(ICategoryService productService)
        {
            _productService = productService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
            
                errorDto.Errors.Add($"id si {id} olan kategori veritabanında bulunamadı");
                context.Result =new RedirectToActionResult("Error","Home",errorDto);
            }
        }
    }
}
