using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies_Web_API.BusinessLayer;

namespace Movies_Web_API.Models
{
    public class Movies_Web_APIDatabaseContext : DbContext
    {
        public Movies_Web_APIDatabaseContext (DbContextOptions<Movies_Web_APIDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Movies_Web_API.BusinessLayer.Movie> Movie { get; set; }
    }
}
