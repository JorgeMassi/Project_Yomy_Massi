using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private readonly IService<Ingredient, int> _service;// la APi usa el servicio entonces tengo que instanciarlo

        public IngredientController(IService<Ingredient, int> service)// Creo un método constructor de un nuevo servicio para probarlo, alt + Enter para crear el método constructor, y también otras cosas.
        {
            _service = service;
        }//


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _service.RetrieveAll();
                
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Ingredient Post([FromBody] Ingredient ingredient)
        {
            return _service.Create(ingredient);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Ingredient Put([FromBody] Ingredient ingredient)
        {
            return _service.Update(ingredient);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
