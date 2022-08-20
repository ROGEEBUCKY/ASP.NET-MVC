using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class Anime
        {
        public List<Sources> Sources { get; set; } = new List<Sources>();
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Episodes { get; set; }
        public string Status { get; set; }
        public Seasons Season { get; set; } = new Seasons();
        public string Picture { get; set; }
        public string ThumbNail { get; set; }
        public List<Synonyms> Synonyms { get; set; } = new List<Synonyms>();
        public List<Relations> Relations { get; set; } = new List<Relations>();
        public List<Tags> Tags { get; set; } = new List<Tags>();
        public List<User> Users { get; set; } = new List<User>();   

        }
    }
