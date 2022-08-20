using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
    {
    public class Movie
        {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string runtime { get; set; }
        public ArrayList genres { get; set; } = new ArrayList();
        public string director { get; set; }
        public string actors { get; set; }
        public string plot { get; set; }
        public string posterUrl { get; set; }
        }
    }