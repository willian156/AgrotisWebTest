using System.ComponentModel.DataAnnotations;

namespace AgrotisWebTest.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime EmissionDatetime { get; set; }
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public List<OrderProductItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public double TotalWeight { get; set; }

    }
    public class OrderProductItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
