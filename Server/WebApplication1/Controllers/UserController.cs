using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.Data.Models;
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
        [HttpGet("{id}")]
        public User GetU(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public bool Create(User user)
        {
            var users = repo.GetUsers();
            foreach (var value in users)
            {
                if (value.Email == user.Email)
                {
                    return false;
                }
            }
            repo.Create(user);
            return true;
        }
        [HttpPut]
        public IActionResult EditUser(User user)
        {
            repo.Update(user);
            return RedirectPermanent("~/api/User");
        }
        [HttpPost("{id}")] 
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/api/User");
        }
        
    }
}