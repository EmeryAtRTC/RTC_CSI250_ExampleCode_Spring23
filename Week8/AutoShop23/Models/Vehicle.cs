using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShop23.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        //navigation properties
        //Vehicle has one customer
        public Customer Customer { get; set; }
        //Vehicle has multiple Service Performed
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }
    }
}
