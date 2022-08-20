using DAL.Models;
using System.Data.Entity;

namespace DAL
    {
    internal class AnimeContext: DbContext
        {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Seasons> Seasons { get; set; }
        public DbSet<Sources> Sources { get; set; }
        public DbSet<Synonyms> Synonyms { get; set; }
        public DbSet<Relations> Relations { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<User> Users { get; set; }  
     
        }
    }
