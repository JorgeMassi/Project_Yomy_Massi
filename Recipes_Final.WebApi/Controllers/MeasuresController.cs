using Microsoft.AspNetCore.Mvc;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes_Final.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly IService<Measures, int> _service;

        public MeasuresController(IService<Measures, int> service)
        {
            _service = service;
        }

        //
        // GET: api/<MeasuresController>
        [HttpGet]
        public IEnumerable<Measures> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<MeasuresController>/5
        [HttpGet("{id}")]
        public Measures Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<MeasuresController>
        [HttpPost]
        public Measures Post([FromBody] Measures measures)
        {
            return _service.Create(measures);
        }

        // PUT api/<MeasuresController>/5
        [HttpPut("{id}")]
        public Measures Put( [FromBody] Measures measures)
        {
            return _service.Update(measures);   
        }

        // DELETE api/<MeasuresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
