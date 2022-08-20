using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
    {
    public class Cart
        {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        }
    }
