using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplication1.Data.Models;
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
        public IActionResult Create(int[] obj)
        
        {
            Request.Headers.TryGetValue("id", out StringValues vs);
            var id = Convert.ToInt32(vs.ToArray()[0]);
            for (int i = 0; i < obj.Length; i++)
            {
                PollProcess pollProcess = new PollProcess();
                pollProcess.Id = 1;
                pollProcess.Id_User = id;
                pollProcess.Id_Variant = obj[i];
                repo.Create(pollProcess);
            }
            return RedirectPermanent("~/api/PollProcess");
        }
        [HttpPut]
        public IActionResult EditPollProcess(PollProcess pollProcess)
        {

            repo.Update(pollProcess);
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