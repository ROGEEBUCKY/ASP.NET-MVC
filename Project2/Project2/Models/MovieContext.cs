using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2.Models
    {
    public class MovieContext : DbContext
        {
        public DbSet<Movie> movies { get; set; }
        public  DbSet<Customers> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public MovieContext()
            :base("MovieContext")
            {

            }
        }
    }