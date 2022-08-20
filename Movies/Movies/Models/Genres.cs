using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
    {
    public class Genres
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        }
    }