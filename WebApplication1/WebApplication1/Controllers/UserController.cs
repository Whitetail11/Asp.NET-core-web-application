using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

        UserPepository repo = new UserPepository();
        [HttpGet]
        [Route("User/Get")]
        public List<User> GetUs()
        {
            var users = repo.GetUsers();
            return users;
        }
        [Route("User/Get/{id?}")]
        [HttpGet]
        public string GetU(int id)
        {
            return repo.Get(id).Email;
        }
        [HttpPost]
        [ActionName("CreateUser")]
        public IActionResult Create(User user)
        {
            repo.Create(user);
            return RedirectPermanent("~/User/Get");
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditUser(User user)
        {
            repo.Update(user);
            return RedirectPermanent("~/User/Get");
            //repo.Delete(12);
            //return "CLASSNO!!";
            //User user = new User();
            //user.Age = 22;
            //user.Email = "danyahvost03@gmail.com";
            //user.Nickname = "Danya_hvost";
            //user.Password = "556633";
            //user = repo.Create(user);
            //return user.Email; 
            //User user = repo.Get(id);
            //return user.Nickname;
        }
        [Route("User/delete/{id?}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectPermanent("~/User/Get");
        }
        
    }
}