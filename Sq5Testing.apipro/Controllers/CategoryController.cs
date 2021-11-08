using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sq5Testing.apipro.Models;
using Sq5Testing.apipro.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sq5Testing.apipro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;
        public CategoryController(ICategoryRepository categoryRepository,
            ApplicationDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _categoryRepository.GetCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(Guid id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            if (ModelState.IsValid)
            {
                if(await IsExist(category.CategoryName))
                {
                    return BadRequest("This category name is already exist");
                }
                if (await _categoryRepository.SaveCategory(category))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            return BadRequest(ModelState);
        }
        private async Task<bool> IsExist(string name)
            => await _context.Category.AnyAsync(x => x.CategoryName.Equals(name));
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
