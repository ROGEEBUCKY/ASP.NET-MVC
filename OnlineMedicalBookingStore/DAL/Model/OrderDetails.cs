using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
    {
    public class OrderDetails
        {
        public int Id { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        }
    }
