using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
    {
    public class Product
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public string Image { get; set; }
        public string Manufacturer { get; set; }
        public float Discount { get; set; }
        [ForeignKey("Remark")]
        public int RemarkId { get; set; }
        public Remark Remark { get; set; }
        public int Stock { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float FinalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        }
    }
