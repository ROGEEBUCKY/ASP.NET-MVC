using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
    {
    public class MovieBookingContext : DbContext
        {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Movie> Movie { get; set; }
        public MovieBookingContext()
            :base("MovieBookingContext")
            {

            }
        }
    }