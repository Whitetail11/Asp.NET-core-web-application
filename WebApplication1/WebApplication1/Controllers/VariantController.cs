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
    public class VariantController : Controller
    {
        VariantRepository repo = new VariantRepository();
        [HttpGet]
        public List<Variant> Getvars()
        {
            return repo.GetVariants();
        }
        [HttpGet("{id}")]
        public Variant Getvar(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public IActionResult Create(Variant variant)
        {
            repo.Create(variant);
            return RedirectPermanent("~/api/Variant");
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditVar(Variant variant)
        {
            repo.Update(variant);
            return RedirectPermanent("~/api/Variant");
        }
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/api/Variant");
        }
    }
}