using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OctpsBox.Data.UnitOfWork;
using OctpsBox.Data.GenericRepository;
using OctpsBox.Data.Models;

namespace OctpsBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGenericRepository<Kullanici> _userRepository;

        public ValuesController(IUnitOfWork uow)
        {
            _userRepository = uow.GetRepository<Kullanici>();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var users = _userRepository.Get(x => x.Id != 0).ToList();
            string[] a = new string[users.Count];
            var index = 0;
            foreach (var item in users)
            {
                a[index] = item.KullaniciAdi;
                index++;
            }

            return a;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
