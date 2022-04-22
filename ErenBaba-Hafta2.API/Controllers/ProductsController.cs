using AutoMapper;
using ErenBaba_Hafta2.API.DTOs;
using ErenBaba_Hafta2.API.Models;
using ErenBaba_Hafta2.Domain;
using ErenBaba_Hafta2.Domain.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErenBaba_Hafta2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetQuery().ToList());
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] ProductQueryDto search)
        {
            IQueryable<Product> query = _productRepository.GetQuery();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            if (!string.IsNullOrEmpty(search.Category))
            {
                query = query.Include(a=>a.Category).Where(x => x.Category.Name == search.Category);
            }
            if (search.Price > 0)
            {
                query = query.Where(x => x.Price >= search.Price);
            }

            return await query.ToListAsync();
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductDto product)
        {
            var dto = _mapper.Map<ProductDto, Product>(product);

            if (id != product.Id)
            {
                return BadRequest();
            }
            var obj = _productRepository.Find(product.Id);
            if (obj != null)
            {
                _productRepository.Update(dto);
            }
            else
            {
                _productRepository.Add(dto);
            }
            _productRepository.Save();
            return Ok(_productRepository.GetQuery().ToList());
        }

        [HttpPost]
        public IActionResult PostProduct(ProductDto product)
        {
            var obj = _mapper.Map<ProductDto, Product>(product);
            try
            {
                _productRepository.Add(obj);
                _productRepository.Save();
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_productRepository.GetQuery().ToList());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var product = _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Remove(id);
            _productRepository.Save();

            return Ok();
        }


    }
}
