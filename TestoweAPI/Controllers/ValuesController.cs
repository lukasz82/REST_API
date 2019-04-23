using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestoweAPI.Models.EF;

namespace TestoweAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly lkazimieContext _context;

        public ValuesController(lkazimieContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public IEnumerable<string> Get()
        public JsonResult Get()
        {
            var result = (from a in _context.Movie select a);
            return Json(result);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (id > 10)
            {
                //var dBContext = _context.Movie.Include(m => m.Author).Include(m => m.Genres);
                var result = (from a in _context.Movie select a).ToList();
                return "xxx";
            }
            
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
