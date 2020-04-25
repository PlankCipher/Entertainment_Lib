using Entertainment_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entertainment_Lib.ViewModels
{
    public class MovieHomeViewModel
    {
        public Movie movie { get; set; }
        public string currentUserId { get; set; }
    }
}