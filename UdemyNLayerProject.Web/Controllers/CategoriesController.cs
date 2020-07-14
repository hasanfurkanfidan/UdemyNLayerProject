using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Service;
using UdemyNLayerProject.Web.Dtos;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task< IActionResult> Index()
        {
            var categories =await _categoryService.GetAllAsync();
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
           await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
            }
            else
            {
                return View(categoryDto);
            }
        }
        public IActionResult Update(int id)
        {
           var category =  _categoryService.GetByIdAsync(id).Result;
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult>Update(CategoryDto categoryDto)
        {
            if (ModelState.IsValid) {
                var updatedCategory = await _categoryService.GetByIdAsync(categoryDto.Id);
                updatedCategory.Name = categoryDto.Name;
                updatedCategory.Id = categoryDto.Id;
                _categoryService.Update(updatedCategory);

                return RedirectToAction("Index");
                    }
            return View(categoryDto);
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var deletedCategory = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(deletedCategory);
            return RedirectToAction("Index");
        }
    }
}
