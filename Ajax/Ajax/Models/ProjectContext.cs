using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ajax.Models
    {
    public class ProjectContext : DbContext
        {
        public DbSet<Employee> Employees { get; set; }
        }
    }