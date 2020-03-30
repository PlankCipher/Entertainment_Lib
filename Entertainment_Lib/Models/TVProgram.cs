using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Entertainment_Lib.Models
{
    public class TVProgram
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; }

        public int OwnerId { get; set; }
    }
}