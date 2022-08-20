using DAL.Model;
using System.Data.Entity;

namespace DAL
    {
    public class DBContext : DbContext
        {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DBContext()
            : base("OnlineMedicineDBContext")
            {

            }
        }
    }
