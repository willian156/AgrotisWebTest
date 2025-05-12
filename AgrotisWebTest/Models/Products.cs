using System.ComponentModel.DataAnnotations;

namespace AgrotisWebTest.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Display(Name = "Liquid Weight")]
        public float LiquidWeight { get; set; }
        [Display(Name = "Unitary Price")]
        public float UnitaryPrice { get; set; }

        public List<Orders> Orders { get; set; }
    }
}
