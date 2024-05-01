using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IService<Difficulty, int> _service;

        public DifficultyController(IService<Difficulty, int> service)
        {
            _service = service;
        }
        //

        // GET: api/<DifficultyController>
        [HttpGet]
        public IEnumerable<Difficulty> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<DifficultyController>/5
        [HttpGet("{id}")]
        public Difficulty Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<DifficultyController>
        [HttpPost]
        public Difficulty Post([FromBody] Difficulty difficulty)
        {
            return _service.Create(difficulty);
        }

        // PUT api/<DifficultyController>/5
        [HttpPut("{id}")]
        public Difficulty Put([FromBody] Difficulty difficulty)
        {
            return _service.Update(difficulty); 
        }

        // DELETE api/<DifficultyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
