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
        //private List<Category> _categories;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category==null)
            {
               return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            if (ModelState.IsValid)
            {
                //if(await IsExist(category.CategoryName))
                //{
                //    return BadRequest("This category name is already exist");
                //}
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

    }
}
