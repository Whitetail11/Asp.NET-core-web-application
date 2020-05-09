using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        UserPepository repo = new UserPepository();
        [HttpGet]
        public List<User> GetUs()
        {
            var users = repo.GetUsers();
            return users;
        }
       // [Route("User/Get/{id?}")]
        [HttpGet("{id}")]
        public string GetU(int id)
        {
            return repo.Get(id).Email;
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            repo.Create(user);
            return RedirectPermanent("~/api/User");
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditUser(User user)
        {
            repo.Update(user);
            return RedirectPermanent("~/api/User");
        }
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/api/User");
        }
        
    }
}