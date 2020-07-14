using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.Dtos;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Service;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProductService _productService;
       private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<List<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
           var product =  await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetWithCategoriesById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategortDto>(product));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult>Save(ProductDto productDto)
        {
            await  _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created("", productDto);
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            if(string.IsNullOrEmpty(productDto.Id.ToString())||productDto.Id<=0)
            {
                throw new Exception("Id alanı gereklidir");
            }
            else {
             _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
            }
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deletedEntity);
            return NoContent();
        }
    }
}
