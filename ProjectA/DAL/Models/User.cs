using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class User
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Anime> Animes { get; set; } = new List<Anime>();
       
        public string Email { get; set; }
        public string Password { get; set; }

        }
    }
