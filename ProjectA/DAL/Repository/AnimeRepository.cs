
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
    {
    public class AnimeRepository
        {
        private readonly AnimeContext _context;

        public AnimeRepository()
            {
            _context = new AnimeContext();
            }

        public IEnumerable<Anime> GetAllAnimeList()
            {
            var list = _context.Animes.ToList();
            return list;
            }

        public List<Anime> GetAnimeByName(string name)
            {
            var list = _context.Animes.Where(c => c.Title.ToLower().StartsWith(name.ToLower())).ToList();
            return list;
            }
        public List<Anime> GetSomeAnime(int num)
            {
            var list = _context.Animes.Take(num).ToList();
            return list;
            }

        public Anime GetAnime(int id)
            {
            return _context.Animes.FirstOrDefault(x => x.Id == id);
            }
        }
    }
