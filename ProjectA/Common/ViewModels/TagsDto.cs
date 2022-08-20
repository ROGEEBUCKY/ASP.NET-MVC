using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
    {
    public class TagsDto
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimeDto> Anime { get; set; }  = new List<AnimeDto>();    
        }
    }
