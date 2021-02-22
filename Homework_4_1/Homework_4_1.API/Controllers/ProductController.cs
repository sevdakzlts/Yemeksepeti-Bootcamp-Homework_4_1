using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_4_1.Business.Abstract;
using Homework_4_1.Entities.Concrete;


namespace Homework_4_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IService<Product> _service;

        public ProductController(IService<Product> service)
        {
            this._service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var result = await _service.Get(e => e.ProductId == id);
           return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var result =await _service.Add(product);
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
            var result= await _service.Delete(e => e.ProductId == id);
           return Ok(result);
        }
    }
}
