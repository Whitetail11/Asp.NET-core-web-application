using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PollProcessController : Controller
    {
        PollProcessRepository repo = new PollProcessRepository();
        [HttpGet]
        public List<PollProcess> getpp()
        {
            return repo.GetProcesses();
        }
        [HttpGet("{id}")]
        public PollProcess get(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public IActionResult Create(PollProcess pollProcess)
        {
            repo.Create(pollProcess);
            return RedirectPermanent("~/api/PollProcess");
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPollProcess(PollProcess pollprocess)
        {
            repo.Update(pollprocess);
            return RedirectPermanent("~/api/PollProcess");
        }
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/api/PollProcess");
        }
    }
}