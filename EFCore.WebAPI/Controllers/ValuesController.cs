using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        [HttpGet("Update/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //var hero = new Hero { Nome = nameHero };

            var hero = _context.Heroes
                            .Where(h => h.Id == 1)
                            .FirstOrDefault();
            hero.Nome = "Homem Aranha";
                //_context.Heroes.Add(hero);
                _context.SaveChanges();

            return Ok();
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Hero { Nome = "Capitão América" },
                new Hero { Nome = "Doutor Estranho" },
                new Hero { Nome = "Pantera Negra" },
                new Hero { Nome = "Viúva Negra" },
                new Hero { Nome = "Hulk" },
                new Hero { Nome = "Gavião Arqueiro" },
                new Hero { Nome = "Capitã Marvel" }
                );
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
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var Hero = _context.Heroes
                                .Where(h => h.Id == id)
                                .Single();
            _context.Heroes.Remove(Hero);
            _context.SaveChanges();
        }
    }
}
