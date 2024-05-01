using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, int> _service;

        public CategoryController(IService<Category, int> service)
        {
            _service = service;
        }
        //

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _service.Create(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public Category Put([FromBody] Category category)
        {
            return _service.Update(category);   
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
