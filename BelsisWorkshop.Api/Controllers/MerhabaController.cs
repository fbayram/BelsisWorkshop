using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelsisWorkshop.Api.Controllers
{
    public class MerhabaController : Controller
    {
        private readonly BelsisContext _ctx;

        public MerhabaController(BelsisContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {            var user = _ctx.Users.Include(x => x.Addresses).ToList().LastOrDefault();

            if (user != null)
                return View(user);

            return View();

        }
    }
}