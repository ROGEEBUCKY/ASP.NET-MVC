using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movies.Models
    {
    public class MovieContext : DbContext
        {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genres>  Genres { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public MovieContext()
            :base("DataBaseContext")
            {

            }
        }
    }