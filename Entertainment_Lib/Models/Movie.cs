using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entertainment_Lib.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser Owner { get; set; }
        public int OwnerId { get; set; }
    }
}