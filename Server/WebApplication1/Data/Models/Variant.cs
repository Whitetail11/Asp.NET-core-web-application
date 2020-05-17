using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_Poll { get; set; }
        public User[] Users { get => users; set => users = value; }
        public bool Choose { get => choose; set => choose = value; }

        public User[] users;
        private bool choose = false;

    }
}
