using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IService<Recipes, int> _service;
        public RecipeController(IService<Recipes, int> service)
        {
            _service = service;
        }

        //
        // GET: api/<RecipeController>
        [HttpGet]
       
        public IEnumerable<Recipes> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public Recipes Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<RecipeController>
        [HttpPost]
        public Recipes Post([FromBody] Recipes recipes)
        {
            return recipes;
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public Recipes Put([FromBody] Recipes recipes)
        {
            return _service.Update(recipes);
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);    
        }
    }
}
