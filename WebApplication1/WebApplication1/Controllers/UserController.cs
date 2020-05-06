using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

        UserPepository repo = new UserPepository();
        [HttpPost]
        public IActionResult Create(User user)
        {
            repo.Create(user);
            return RedirectToAction("Index");
        }

        public string Hello()
        {
            return "Hello";
        }
        
        public string Sho()
        {
            repo.Delete(12);
            return "CLASSNO!!";
           //User user = new User();
            //user.Age = 22;
            //user.Email = "danyahvost03@gmail.com";
            //user.Nickname = "Danya_hvost";
            //user.Password = "556633";
            //user = repo.Create(user);
            //return user.Email; 
        }
    }
}