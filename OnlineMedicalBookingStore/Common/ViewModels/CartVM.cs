using System;

namespace Common.ViewModels
    {
    public class CartVM
        {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public int ProductId { get; set; }
        public ProductVM Product { get; set; }
        public float? Price { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        }
    }
