namespace BusinessObjects
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; } = [];
        public Customer Customer { get; set; } = new();
    }
}
