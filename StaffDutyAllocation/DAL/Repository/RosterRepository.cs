using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class RosterRepository
        {
        readonly AppDBContext _DbContext;
        public RosterRepository()
            {
            _DbContext = new AppDBContext();
            }



        public void AddNewRoster(Roster newRoster)
            {
            _DbContext.Roster.AddOrUpdate(newRoster);
            _DbContext.SaveChanges();
            }
        public List<Roster> GetAllRosters()
            {
            return _DbContext.Roster.ToList();
            }

       
        }
    }
