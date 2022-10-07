using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;

        public ValuesController(HeroContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filter/{name}")]
        public ActionResult GetFilter(string name)
        {
            var listHero = _context.Heroes
                .Where(h => h.Nome.Contains(name))
                .ToList();

            //var listHero = (from Hero in _context.Heroes
            //                where Hero.Nome.Contains(name)
            //                select Hero).ToList();

            return Ok(listHero);
        }

        // GET api/values/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var hero = new Hero { Nome = nameHero };

                _context.Heroes.Add(hero);
                _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
