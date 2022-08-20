namespace Common.ViewModels
    {
    public class OrderDetailsVM
        {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderVM Orders { get; set; }
        public int ProductId { get; set; }
        public ProductVM Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        }
    }