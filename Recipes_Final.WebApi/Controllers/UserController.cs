using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User, int> _service;

        public UserController(IService<User, int> service)
        {
            _service = service;
        }
        //
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.RetrieveAll();
        }
        
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _service.Create(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public User Put( [FromBody] User user)
        {
            return _service.Update(user);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);    
        }
    }
}
