using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Web_API.BusinessLayer
{
    //Movie details
    public class Movie
    {
        //Movie Id 
         public int Id { get; set; }

        //Movie name 
        public string Name { get; set; }

        //Movie Genres
        public string Genres { get; set; }

        //Year of release.
        public int ReleasedYear { get; set; }


    }
}
