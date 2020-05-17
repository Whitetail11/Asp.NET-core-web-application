using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PollController : Controller
    {
        PollRepository repo = new PollRepository();
        [HttpGet]
        public List<Poll> GetPs()
        {
            var polls = repo.GetPolls();
            return polls;
        }
        [HttpGet("{id}")]
        public Poll Getp(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public IActionResult Create(Poll poll)
        {            
            //Request.Headers.TryGetValue("id", out StringValues vs);
            //var id = Convert.ToInt32(vs.ToArray()[0]);
            repo.Create(poll);
            return RedirectPermanent("~/api/Poll");
        }
        [HttpPut]
        public IActionResult EditPoll(Poll poll)
        {
            repo.Update(poll);
            return RedirectPermanent("~/api/Poll");
        }
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/api/Poll");
        }

    }
}