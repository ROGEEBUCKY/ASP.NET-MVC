using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
    {
    internal class UserDto
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimeDto> Animes { get; set; } = new List<AnimeDto>();
       
        public string Email { get; set; }
        public string Password { get; set; }

        }
    }
