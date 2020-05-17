using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReqController : Controller
    {
        UserPepository repo = new UserPepository();
        [HttpGet]
        public int Test()
        {
            return 4;
        }
        [HttpPost]
        public int Login(Req req)
        {
            var users = repo.GetUsers();
            int res = 0;
            foreach (var user in users)
            {
                if (user.Email == req.Useremail && user.Password == req.Password)
                {
                    res = user.Id;
                }
            }
            return res;
        }
    }
}