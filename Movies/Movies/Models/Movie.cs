using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Movies.Models;

namespace Movies.Models
    {
    public class Movie
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Runtime { get; set; }
        public List<Genres> Genres { get; set; }= new List<Genres>();
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Plot { get; set; }
        public string PosterUrl { get; set; }



        public List<object> GetMovie()
            {
            var jsonf = new JsonFile();
            var movie = jsonf.GetJson().movies;
            return movie;
            }

        }
    }