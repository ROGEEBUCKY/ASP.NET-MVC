using DAL.Models;
using System.Data.Entity;

namespace DAL
    {
    public class AppDBContext : DbContext
        {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Duty> Duty { get; set; }
        public DbSet<DutyType> DutyTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Roster> Roster { get; set; }
        public DbSet<AssignedDuties> AssignedDuties { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }

        public AppDBContext()
            : base("DutyAllocationDBContext")
            {

            }
        }
    }
