using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        #region Properties
        private static List<Hero> _heroes = new()
        {
            new Hero()
            {
                Id=1,
                Name = "Tony Stark",
                Team = "Avengers",
                SuperHeroName = "Iron Man"
            },
            new Hero()
            {
                Id = 2,
                Name = "Bruce Wayne",
                Team = "Justice League",
                SuperHeroName = "Batman"
            }
        };
        #endregion

        #region HttpRequests
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heroes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heroes.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heroes.Add(hero);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {
            var heroToUpdate = _heroes.FirstOrDefault(x => x.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete = _heroes.FirstOrDefault(x => x.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }

            _heroes.Remove(heroToDelete);
            return Ok();
        }
        #endregion
    }
}
