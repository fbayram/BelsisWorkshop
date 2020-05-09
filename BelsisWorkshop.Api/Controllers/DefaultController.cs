using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelsisWorkshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ITicket _ticket;
        private readonly BelsisContext _ctx;

        public DefaultController(ITicket ticket, BelsisContext ctx)
        {
            _ticket = ticket;
            _ctx = ctx;
        }

        /// <summary>
        /// dfsfdsfdsfsdfs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            var user = _ctx.Users.Include(x => x.Addresses).ToList().LastOrDefault();

            if (user != null)
                return user.Name;
            return "Kullanıcı Bulunamadı";
            // return _ticket.Adi;
        }

        // GET: api/Default/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] pUser userParam)
        {
            var user = new Api.User
            {
                Name = userParam.Adi,
                LastName = userParam.Soyadi
            };

            var address = new Address { Street = userParam.SokakAdi };
            user.Addresses.Add(address);
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}