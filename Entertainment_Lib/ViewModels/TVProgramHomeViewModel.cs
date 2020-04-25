using Entertainment_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entertainment_Lib.ViewModels
{
    public class TVProgramHomeViewModel
    {
        public TVProgram tvprogram { get; set; }
        public string currentUserId { get; set; }
    }
}