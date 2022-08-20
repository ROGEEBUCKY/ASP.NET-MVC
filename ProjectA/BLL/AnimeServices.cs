using AutoMapper;
using Common;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
    {
    public class AnimeServices
        {
        AnimeRepository Dal;
        public AnimeServices()
            {
            Dal = new AnimeRepository();
            }
        public List<AnimeDto> GetSomeAnime()
            {
            var data = Dal.GetSomeAnime(50);
            return data.Select(Mapper.Map<Anime, AnimeDto>).ToList();
            }
        public List<AnimeDto> GetAllAnime()
            {
            var data = Dal.GetAllAnimeList();
            return data.Select(Mapper.Map<Anime, AnimeDto>).ToList();
            }
        public List<AnimeDto> GetAnimeByName(string str)
            {
            var data = Dal.GetAnimeByName(str).Select(Mapper.Map<Anime, AnimeDto>).ToList();
            return data;
            }
        }
    }
