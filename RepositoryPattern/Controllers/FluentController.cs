using Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Filters;
using RepositoryPattern.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluentController : ControllerBase
    {
        // GET: api/<FluentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FluentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FluentController>
        [HttpPost]
        [UserFilter]
        public IActionResult Post([FromBody] User user)
        {
            //GO TO DATA BASE       
            return Ok(user);
        }

        // PUT api/<FluentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FluentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
