using Entertainment_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entertainment_Lib.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Movie> latestMovies { get; set; }
        public IEnumerable<TVProgram> latestTVPrograms { get; set; }
    }
}