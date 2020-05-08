using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PollController : Controller
    {
        PollRepository repo = new PollRepository();
        [HttpGet]
        [Route("Poll/Get")]
        public IEnumerable<Poll> GetPs()
        {
            var polls = repo.GetPolls();
            return polls;
        }
        [HttpGet]
        [Route("Poll/Get/{id?}")]
        public Poll Getp(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        [ActionName("CreatePoll")]
        public IActionResult Create(Poll poll)
        {
            repo.Create(poll);
            return RedirectPermanent("~/Poll/Get");
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPoll(Poll poll)
        {
            repo.Update(poll);
            return RedirectPermanent("~/Poll/Get");
        }
        [Route("Poll/delete/{id?}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/Poll/Get");
        }

    }
}