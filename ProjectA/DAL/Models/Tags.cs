using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class Tags
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Anime> Anime { get; set; }  = new List<Anime>();    
        }
    }
