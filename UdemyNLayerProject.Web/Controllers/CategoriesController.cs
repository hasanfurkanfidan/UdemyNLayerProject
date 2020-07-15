using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Service;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.Dtos;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper,CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task< IActionResult> Index()
        {
            var categories =await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<List<CategoryDto>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid) { 
           await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
            }
            else
            {
                return View(categoryDto);
            }
        }
        public IActionResult Update(int id)
        {
           var category =  _categoryApiService.GetByIdAsync(id).Result;
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult>Update(CategoryDto categoryDto)
        {
            if (ModelState.IsValid) {
                
               await _categoryApiService.Update(categoryDto);

                return RedirectToAction("Index");
                    }
            return View(categoryDto);
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            
            await _categoryApiService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

    }
}
