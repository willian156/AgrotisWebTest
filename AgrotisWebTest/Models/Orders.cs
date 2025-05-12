using System.ComponentModel.DataAnnotations;

namespace AgrotisWebTest.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime EmissionDatetime { get; set; }
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public List<Products> Products { get; set; }
        public double TotalPrice { get; set; }
        public double TotalWeight { get; set; }

    }
}
