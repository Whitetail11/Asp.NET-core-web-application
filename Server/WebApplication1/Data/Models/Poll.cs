using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DeadLine { get; set; }
        public int Author_Id  { get; set; }
        public int MaxVariantByUser { get; set; }
        public Variant [] variants { get; set; }
        public bool IsActive { get; set; }
        public bool IsCanAddVariants { get; set; }
    }
}
