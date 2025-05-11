using System.ComponentModel.DataAnnotations;

namespace AgrotisWebTest.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "IBGE Code")]
        public string IbgeCode { get; set; }
        [Display(Name = "Address number")]
        public int AddressNumber { get; set; }

    }
}
