using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
    {
    internal class TradingContext : DbContext
        {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FundRemark> FundRemarks { get; set; }
        public DbSet<Funds> Funds { get; set; }
        public DbSet<Investment> Investments { get; set; }

        }
    }
